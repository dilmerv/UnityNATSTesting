# NATS IO Testing in Unity

This repository contains a demo Unity3d project showing how we can connect to a NATS IO server right from within Unity.

Few things to know:

1. NATS.Client DLLs are all packaged under Assets/Packages/NATS.Client.0.8.1
2. A testing scene is included under Assets/Scenes/NATSTesting
3. GameObject "MessageBusManager" contains a script called "MessageBusManager.cs"
4. MessageBusManager.cs uses Text UI component to display the messages published to the message bus.
5. MessageBusManager.cs has a defaultNATSUrl 
6. A singleton pattern is used in the MessageBusManager.cs which is located under Assets/Scripts/Core
