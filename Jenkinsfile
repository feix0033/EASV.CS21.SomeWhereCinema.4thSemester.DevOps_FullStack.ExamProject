pipeline{

    agent any

    triggers{
        pollSCM("* * * * *")
    }

    stages{

         stage("Branch Build"){
            steps{
                sh "dotnet build"
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

        stage("unitTest"){
            steps{
                echo "====++++executing dotnet test ++++===="
                sh 'cd SomeWhereCinema.Backend/Test.Domain.Core/'
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

        stage("Branch merge"){
            steps{
                echo "====++++executing Branch merge++++===="
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Branch merge executed successfully++++===="
                }
                failure{
                    echo "====++++Branch merge execution failed++++===="
                }
        
            }
        }

        stage("Main Build"){
            steps{
                echo "====++++executing Main Build++++===="
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Main Build executed successfully++++===="
                }
                failure{
                    echo "====++++Main Build execution failed++++===="
                }
        
            }
        }

        stage("Main Test"){
            steps{
                echo "====++++executing Main Test++++===="
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Main Test executed successfully++++===="
                }
                failure{
                    echo "====++++Main Test execution failed++++===="
                }
        
            }
        }

        stage("Main Deploy"){
            steps{
                echo "====++++executing Main ++++===="
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Main  executed successfully++++===="
                }
                failure{
                    echo "====++++Main  execution failed++++===="
                }
        
            }
        }

        stage("Main Deliver"){
            steps{
                echo "====++++executing Main Deliver++++===="
            }
            post{
                always{
                    echo "====++++always++++===="
                }
                success{
                    echo "====++++Main Deliver executed successfully++++===="
                }
                failure{
                    echo "====++++Main Deliver execution failed++++===="
                }
        
            }
        }

    }
}
