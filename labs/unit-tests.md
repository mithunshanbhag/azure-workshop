# Unit tests

## #1: Generate code coverage results (dotnet CLI)

* Install the dotnet report generator (global tool)

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

* Generate code coverage statistics while running unit tests

```bash
dotnet test --collect:"XPlat Code Coverage"
```

* Generate code coverage report

```bash
reportgenerator -targetdir:"coveragereport" -reporttypes:Html -reports:"TestResults\{PATH}\coverage.cobertura.xml"
```

* The report can be accessed at: `coveragereport\index.html`

## #2: Generate code coverage results (pipeline)

Add the following snippet to your CI pipeline

```yaml
- task: DotNetCoreCLI@2
  displayName: dotnet test
  inputs:
    command: 'test'
    arguments: --collect:"XPlat Code Coverage"

- task: PublishCodeCoverageResults@1
  displayName: publish code coverage results
  inputs:
    codeCoverageTool: 'Cobertura'
    summaryFileLocation: '$(Agent.TempDirectory)/**/*coverage.cobertura.xml'
    failIfCoverageEmpty: true
```

* The report can be accessed on the `Code Coverage` tab in the pipeline build results.
