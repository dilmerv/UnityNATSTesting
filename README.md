# NATS IO Testing in Unity

This repository contains a demo Unity3d project showing how we can connect to a NATS IO server right from within Unity.

Few things to know:

1. A testing scene is included under Assets/Scenes/NATSTesting
2. GameObject "MessageBusManager" contains a script called "MessageBusManager.cs"
3. MessageBusManager.cs uses Text UI component to display the messages published to the message bus.
4. MessageBusManager.cs has a defaultNATSUrl 
5. A singleton pattern is used in the MessageBusManager.cs which is located under Assets/Scripts/Core

