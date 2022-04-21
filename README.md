# Snappable Meshes PCG

An implementation of the Snappable Meshes PCG technique in Unity.

## What is it?

The Snappable Meshes PCG technique consists of a system of connectors with pins
and colors which constrains how any two map pieces (i.e., meshes) can snap
together. Through the visual design and specification of these connection
constraints, and an easy-to-follow generation procedure, the method is
accessible to game designers and/or other non-experts in PCG, AI or programming.

This repository contains a prototype implementation of this technique developed
in the Unity game engine. It is currently implemented using Unity 2020.3 LTS.

## How does it work?

![01](https://user-images.githubusercontent.com/3018963/127988176-a3002b05-bc4c-4eb1-b817-b6fd955e6b85.png)
![02](https://user-images.githubusercontent.com/3018963/127988173-6c761e64-6e91-464d-b5e0-6449a7ac3978.jpg)
![03](https://user-images.githubusercontent.com/3018963/147121060-0631634a-be54-46e6-8e06-bf867b03a845.png)

## More information

e Silva, R. C., Fachada, N., de Andrade, D., & Códices, N. (2022). Procedural
Generation of 3D Maps with Snappable Meshes. IEEE Access, 10.
<https://doi.org/10.1109/ACCESS.2022.3168832>

## Third-party plugins

This software uses the following third-party plugins:

* [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes)
  (MIT License)
* [Array2DEditor](https://github.com/Eldoir/Array2DEditor) (MIT License)

## License

[Apache 2.0](LICENSE)