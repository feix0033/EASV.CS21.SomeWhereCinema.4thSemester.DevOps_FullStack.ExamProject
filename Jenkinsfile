pipeline{

    agent any
    environment {
        DOTNET_ROOT = "/usr/local/share/dotnet/"
        PATH = "/usr/local/share/dotnet/:$PATH"
    }
    triggers{
        pollSCM("* * * * *")
    }
    stages{
        stage("unitTest"){
            steps{
                echo "====++++executing dotnet test ++++===="
                dir('SomeWhereCinema.Backend/Test.Domain.Core/'){
                    sh "dotnet test"
                }
            }
            
        }
         stage("Build"){
            steps{
                dir('SomeWhereCinema.Backend'){
                    sh "dotnet build"
                }
            }
            post{
                always{
                    echo "====++++ the first build stage ++++===="
                }
                success{
                    echo "=== Build are success"
                }
                failure{
                    echo "=== Build failure"
                }
        
            }
        }
       

        stage("Branch Test"){
            steps{
                echo "====++++executing Branch Test++++===="
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Branch Test executed successfully++++===="
                }
                failure{
                    echo "====++++Branch Test execution failed++++===="
                }
        
            }
        }
    }
}
