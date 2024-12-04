# Unity Nuclear Reactor Simulator (Early Developement)

Im developing a **2D Unity simulation** that provides an **abstract representation** of nuclear reactor processes. The project will visualize reactor dynamics to highlight core concepts such as energy generation, heat transfer, and particle interactions, prioritizing accessibility and educational value over realism.

---

## Current Progress:
Currently developing a suitable abstraction to model a water coolant loop in a reactor, 
- First prototype involved water particles with dynamic RB's and intial energy and a tilemap container with a fully elastic, frictionless physics materal.
- Particles instantiated randomly in container area and move freely more like a gas,
- Currenly working on a system using a line rendered flow path and proxial 2D springs to model particle cohesion and an abstraction of directional flow.

## Planned Features:
Including but not limited to:  

**Abstract Reactor Components**
- Fuel,
- Control rods,
- Coolant systems/loops,
- Heat Exchanger etc

**Particle Representation**:
- **Neutrons**: Drive fission reactions,
- **Coolant (e.g., water)**: Absorbs and transfers heat,
- **Radiation (alpha, beta, gamma)**.

**System Dynamics**:
- Heat and energy modeled visualy using colours and UI elements,
- Visual feedback for key interactions (animations/sound): e.g., for particle collisions, moving control rods, etc...

**User Interaction/Scripted run**:
- Depending on the scope/complexity of the project i may implement user interaction or just run a preset script of actions.

**Different reactor types**:
- to allow for creation of scenes with dfferent reactor designs such as Pressurized Water Reactors (PWRs), or Boiling Water Reactors (BWRs) dynamically.

## Project Aims:
To develop a usefull representation of a nuclear reactor and to bolster my understanding of the nuclear power generation process in an interesting way.



