## Changelog

### v0.16 (2025-07-24)
#### Added
- Bekesy-method audiogram

---

### v0.15 (2025-07-23)
#### Added
- Basic measurement tab
  - Restored Audiogram, LDL, Questionnaires (checklists only)
#### Fixed
- Race conditions instantiating new signal in Turandot Interactive

---

### v0.14 (2025-07-10)
#### Fixed
- Turandot: receive audio sync log as direct response to request, to ensure it is received before subsequent scene change

---

### v0.13 (2025-07-08)
#### Changed
- tried to fix race condition where stream status check did not get stopped, causing the streams to periodically register incorrectly register as "idle"

---

### v0.12 (2025-07-02)
#### Added
- Pupil dynamic range: exposed min and max screen intensity

### v0.11 (2025-06-26)
#### Added
- option to hide protocol entry from subject-facing outline
- optional protocol entry instructions

---

### v0.10 (2025-06-19)
#### Added
- communication of LED color changes with tablet
- exposed pupil dynamic range properties

---

### v0.9 (2025-06-12)
#### Changed
- add project-specific MATLAB folder to MATLAB engine path

---

### v0.8 (2025-05-30)
#### Added 
- features to facilitate developing projects

---

### v0.7 (2025-05-13)
#### Added
- Protocol: ability to select next test
- transmit metrics to Turandot Editor (if running)
#### Fixed
- Protocol: better response to measurements aborted on the tablet side
- Pupil dynamic range:
  - better logging
  - require Eyelink stream (or else what's the point)

---

### v0.6 (2025-04-24)
#### Added
- Protocol control

---

### v0.5 (2025-04-18)
#### Added
- connection to MATLAB engine
- user metrics

---

### v0.4 (2025-04-11)
#### Added
- gaze calibration
- subject-specific background color

---

### v0.3 (2025-04-10)
#### Fixed
- change data folder when subject is Changed
#### Added
- control of pupil dynamic range measurement

---

### v0.2 (2025-04-07)
#### Added
- retrieve log from tablet
#### Changed
- Install stream icons

---

### v0.1 (2025-04-04)
- initial release for use in C462

