**Overview**  

The Human Test Suite (HTS) has three main software components, illustrated in the figure below.

1. The **HTS** itself is the *subject-facing* app. Often called the "tablet app" because it has historically run on a tablet device, it can run on any Windows device (tablet, laptop, PC). 
2. The **HTS Controller** is the *researcher-facing* app. It typically runs on a separate PC connected to the subject device by a direct Ethernet connection. It allows the researcher to control the HTS app as if they were sitting in front of it. It has other important functions described below.
3. The **Turandot Editor** is a tool for creating arbitrary and relatively sophisticated psychophysical tests to run in the HTS app. It can optionally communicate with each of the other two apps.

Note a couple of things:

- each of the apps can be run by itself.
- the HTS app can be run on the same device as the HTS controller. In fact, this is the easiest way to work on setting up and debugging the testing protocol.

![](<images/system overview.png>)