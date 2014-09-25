### Executor 

UNSTABLE - INCOMPLETE

The idea behind the Executor framework came from the need to create different types of executables easily. Having a single console application or service that runs your different types of apps with a layer of abstraction that allows you to concentrate on writing your code.

This is especially good for:

- Task based systems
- Producer / Consumer / Parallel Processing system.

You reference the library, implemenet a base class and you can plug your assembly into the executor and run it. 

This is incomplete and we stil have to complete the initial wrapper implementation:

- Workflow system
- Bootstraping
- Multiple executor context awareness

## Use

Reference Executor.Library in your project.

Annotate a class with ExecutorAttribute and extend ExecutorBase. 

Logic goes in run.

These instructions will be completed later... 


