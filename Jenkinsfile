pipeline {
    agent any
    environment {
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        HOME = "/tmp/DOTNET_CLI_HOME"
    }
    stages {
        stage ('CI_UnitTest_Backend'){
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:7.0'
                }
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
                    echo 'remove histiory test results'
                    sh 'rm -rf TestResults'
                    sh 'dotnet add package coverlet.collector'
                    sh 'dotnet test --collect:\'Xplat Code Coverage\''
                }
            }
            post {
                    success {
                        dir(path: 'SomeWhereCinema.Backend'){
                            archiveArtifacts 'SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'

                        publishCoverage adapters: 
                        [
                            istanbulCoberturaAdapter
                            (
                                path: 'SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml', 
                                thresholds:
                                [[
                                failUnhealthy: true,
                                thresholdTarget: 'Conditional',
                                unhealthyThreshold: 80.0, // below 80%
                                unstableThreshold: 50.0  // below 50%
                                ]]
                            )
                        ],
                        checksName: ''
                        sourceCodeRetention(NEVER)
                        }
                    }
                }
        }
    }
}