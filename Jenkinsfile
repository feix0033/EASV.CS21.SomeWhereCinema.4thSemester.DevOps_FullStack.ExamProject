pipeline{

    agent any

    // environment {
    //     // DOTNET_ROOT = "/usr/local/share/dotnet/"
    //     // PATH = "/usr/local/share/dotnet/:$PATH"

    //     // NODE_ROOT = '/Users/evens/.nvm/versions/node/v16.20.0/bin/'
    //     // PATH = '/Users/evens/.nvm/versions/node/v16.20.0/bin/:$PATH'
    // }

    tools {nodejs "NodeJS-local"}

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
                    sh 'apt update'
                    sh 'apt install Node.js'
                    sh 'apt install npm'
                    sh 'npm install'
                //     sh 'npm run build'
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
