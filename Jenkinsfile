pipeline{

    agent any
    environment {
        
    }
    triggers{
        pollSCM("* * * * *")
    }
    stages{
         stage("Build"){
            steps{
                echo 'build branch'
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
