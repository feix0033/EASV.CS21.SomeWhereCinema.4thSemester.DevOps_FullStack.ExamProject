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
       
        stage("Build"){
            steps{
                // dir('SomeWhereCinema.Backend'){
                //     sh "dotnet build"
                // }
                dir('SomeWhereCinema.Frontend'){
                    sh 'npm install'
                    sh 'npm run build'
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
