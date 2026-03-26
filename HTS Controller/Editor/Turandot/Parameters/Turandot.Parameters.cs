using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

using KLib.Signals;
using C462.Shared;
using C462.Shared.Turandot;

// ── Namespace: Turandot ──────────────────────────────────────────────────────

namespace Turandot
{
    public enum TrialLogOption { None, Save, Upload }
    public enum EndAction { None, EndRun, AbortAll }
    public enum TermType { Any, CSplus, CSminus }
    public enum TerminationAction { LetStateFinish, EndImmediately }
    public enum InputState { High, Low, Rising, Falling }
    public enum InputOperator { None, AND, OR }
    public enum Comparison { LT, LE, EQ, NE, GT, GE }

    public class Flag
    {
        public string name;
        public int value;

        public Flag() { }
        public Flag(string name) { this.name = name; }
        public override string ToString() => name + " = " + value;
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Termination
    {
        public TermType type = TermType.Any;
        public string source;
        public string linkTo = "";
        public float latency_ms = 0;
        public string result = "";
        public string flagExpr = "";
        public TerminationAction action = TerminationAction.EndImmediately;

        public Termination() { }
        public Termination(string source) { this.source = source; }
        public Termination(string source, string linkTo) { this.source = source; this.linkTo = linkTo; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Timeout
    {
        public string expr = "1";
        public string linkTo = "";
        public TermType termType = TermType.Any;
        public string result = "";

        [XmlIgnore] [JsonIgnore] public float Value { get; set; }

        public Timeout() { }
        public Timeout(string expr, string linkTo) { this.expr = expr; this.linkTo = linkTo; }
        public void Initialize() { }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class InputCriterion
    {
        public string control;
        public InputState state;
        public float time_ms;
        public InputOperator op;
        public Comparison comparison = Comparison.EQ;

        public InputCriterion() { }
        public void Reset() { }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class InputEvent
    {
        public string name;
        public List<InputCriterion> criteria = new List<InputCriterion>();

        public InputEvent() { }
        public InputEvent(string name) { this.name = name; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class FlowElement
    {
        public string name = "";
        public bool isAction = false;
        public SignalManager sigMan = null;
        public List<Cues.Cue> cues = new List<Cues.Cue>();
        public List<Inputs.Input> inputs = new List<Inputs.Input>();
        public List<Timeout> timeOuts = new List<Timeout>();
        public List<Termination> term = new List<Termination>();
        public string ipcCommand = "";
        public EndAction endAction = EndAction.None;
        public bool hideCursor = false;
        public TurandotAction action = null;

        public FlowElement() { }
        public FlowElement(string name) { this.name = name; timeOuts.Add(new Timeout()); }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Parameters
    {
        public Instructions instructions = new Instructions();
        public Screen.ScreenElements screen = new Screen.ScreenElements();
        public List<InputEvent> inputEvents = new List<InputEvent>();
        public List<FlowElement> flowChart = new List<FlowElement>();
        public string firstState = "";
        public List<Flag> flags = new List<Flag>();
        public Schedules.Schedule schedule = new Schedules.Schedule();
        public Schedules.Adaptation adapt = new Schedules.Adaptation();
        public string tag = "";
        public string wavFolder = "";
        public TrialLogOption trialLogOption = TrialLogOption.Upload;
        public bool allowExpertOptions = false;
        public string matlabFunction = "";

        public Parameters() { }

        public FlowElement this[string name]
        {
            get { return flowChart.Find(fe => fe.name == name); }
        }

        public void ClearExpertOptions()
        {
            foreach (var fe in flowChart)
            {
                if (fe.sigMan != null) fe.sigMan.ClearExpertOptions();
                foreach (var t in fe.term) t.flagExpr = "";
            }
        }
    }
}

// ── Namespace: Turandot.Screen ───────────────────────────────────────────────

namespace Turandot.Screen
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ScreenElements
    {
        public List<CueLayout> Cues { get; set; }
        public List<InputLayout> Inputs { get; set; }
        public bool ApplyCustomScreenColor { get; set; }
        public string finalPrompt = "";
        public bool ApplyParamSpecificScreenColor { get; set; }
        public int Color { get; set; }

        public ScreenElements()
        {
            Cues = new List<CueLayout>();
            Inputs = new List<InputLayout>();
            ApplyCustomScreenColor = false;
            ApplyParamSpecificScreenColor = false;
            Color = -1;
        }
    }
}

// ── Namespace: Turandot.Schedules ────────────────────────────────────────────

namespace Turandot.Schedules
{
    public enum Mode { Sequence, CS, Adapt, Optimize }
    public enum Order { Interleave, Sequential, Alternate, Random }
    public enum VariableOrder { FullRandom, XSeqYSeq, XSeqYRand, XRandYSeq, XRandYRand }
    public enum TrialType { NoResult, GoNoGo, CSplus, CSminus }
    public enum AdaptMode { GoNoGo, CS }
    public enum AdaptSwitchType { Reversals, Trials }
    public enum AdaptComputation { Mean, Median }

    [JsonObject(MemberSerialization.OptOut)]
    public class Variable
    {
        public string state = "";
        public VarDimension dim = VarDimension.X;
        public string expression = "";

        public Variable() { }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Family
    {
        public string name = "";
        public int number = 0;
        public bool oneEach = true;
        public TrialType type = TrialType.NoResult;
        public VariableOrder order = VariableOrder.FullRandom;
        public List<Variable> variables = new List<Variable>();
        public string resultExpression = "";
        public string storeResultAs = "";

        public Family() { }
        public Family(string name) { this.name = name; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class AdaptiveTrack
    {
        public string name = "";
        public float startVal = 0;
        public TrialType trackedVarType = TrialType.GoNoGo;
        public List<Variable> variables = new List<Variable>();
        public List<Variable> catches = new List<Variable>();
        public AdaptComputation computation = AdaptComputation.Mean;

        public AdaptiveTrack() { }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Schedule
    {
        public Mode mode = Mode.Sequence;
        public int numBlocks = 1;
        public string decisionState = "";
        public Order order = Order.Interleave;
        public List<Family> families = new List<Family>();
        public bool training = false;
        public float targetPc = 0;
        public string performancePrompt = "";
        public float targetCV = 0.2f;
        public int maxExtraBlocks = 0;
        public int offerBreakAfter = 0;
        public string breakInstructions = "";
        public int maxPracticeBlocks = -1;

        public Schedule() { }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Adaptation
    {
        public int switchAfter = -1;
        public int numBlocks = 1;
        public AdaptSwitchType switchType = AdaptSwitchType.Reversals;
        public AdaptMode mode = AdaptMode.GoNoGo;
        public List<AdaptiveTrack> tracks = new List<AdaptiveTrack>();
        public float cvCriterion = 0.2f;
        public int maxExtraBlocks = 0;
        public bool randomTrackOrder = true;

        public Adaptation() { }
    }
}
