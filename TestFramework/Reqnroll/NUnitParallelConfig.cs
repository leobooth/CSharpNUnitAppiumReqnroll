using NUnit.Framework;

/*
    // https://docs.reqnroll.net/latest/execution/parallel-execution.html#nunit-configuration

    NUnit Configuration
    By default, NUnit does not run the tests in parallel. 
    Parallelization must be configured by setting an assembly-level attribute in the Reqnroll project.

    C# file for configuring feature-level parallelization
    using NUnit.Framework;
    [assembly: Parallelizable(ParallelScope.Fixtures)]
    
    C# file for configuring scenario-level parallelization
    using NUnit.Framework;
    [assembly: Parallelizable(ParallelScope.Children)]
*/

[assembly: Parallelizable(ParallelScope.Fixtures)]