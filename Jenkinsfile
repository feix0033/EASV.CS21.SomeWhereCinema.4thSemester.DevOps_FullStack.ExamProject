pipeline {
    agent none

    triggers{
        pollSCM("* * * * *")
    }
    
    environment {
        CI = 'true' 
        DOTNET_ROOT="/usr/bin/dotnet"
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        agent any

        stage("Build FrontEnd"){
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps{
                echo "====++++executing Build FrontEnd++++===="
                dir ('SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    sh 'npm install npm'
                    sh 'npm install'
                    sh 'npm i -g @angular/cli'
                    try {
                        sh 'ng build'
                    }
                    catch (exception) {
                        echo 'Caught: ${exception}'
                        onCatch
                    }
                }
            }
            post{
                always{
                    echo "====++++Build FrontEnd executed finish++++===="
                }
                success{
                    echo "====++++Build FrontEnd executed successfully++++===="
                }
                failure{
                    echo "====++++Build FrontEnd execution failed++++===="
                }
        
            }
        }

        stage("Build BackEnd"){
            agent any

            steps{
                echo "====++++executing Build BackEnd++++===="
                sh 'pwd'
                dir ('SomeWhereCinema.Backend'){
                    sh 'dotnet build'
                }
            }
            post{
                always{
                    echo "====++++alwayBuild BackEnd executed finish++++===="
                }
                success{
                    echo "====++++Build BackEnd executed successfully++++===="
                }
                failure{
                    echo "====++++Build BackEnd execution failed++++===="
                }
        
            }
        }

        stage("Test BackEnd"){
            steps{
                echo "====++++executing Test BackEnd++++===="
                dir("")
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Test BackEnd executed successfully++++===="
                }
                failure{
                    echo "====++++Test BackEnd execution failed++++===="
                }
        
            }
        }

        stage("Deploy"){
            agent any

            steps{
                echo "====++++executing Deploy++++===="
            }
            post{
                always{
                    echo "====++++Deploy finish++++===="
                }
                success{
                    echo "====++++Deploy executed successfully++++===="
                }
                failure{
                    echo "====++++Deploy execution failed++++===="
                }
        
            }
        }

        stage("Deliver"){
             agent any

            steps{
                echo "====++++executing Deliver++++===="
            }
            post{
                always{
                    echo "====++++Devliver finishi++++===="
                }
                success{
                    echo "====++++Deliver executed successfully++++===="
                }
                failure{
                    echo "====++++Deliver execution failed++++===="
                }
            }
        }
    }

    post {
        always{
            echo "====++++All stages finish++++===="
            deleteDir()
        }
        success{
            echo "====++++successfully++++===="
        }
        failure{
            echo "====++++failed++++===="
        }
    }

}