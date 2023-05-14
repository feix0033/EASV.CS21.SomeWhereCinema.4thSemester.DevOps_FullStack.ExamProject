pipeline {
    agent any

    triggers {
        pollSCM('* * * * *')
    }

    environment {
        CI = 'true'
        DOTNET_ROOT = '/usr/bin/dotnet'
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        // Continuous Integrate FrontEnd
        stage('Merge FrontEnd') {
            when {
                branch('FrontEnd*')
            }
            agent any
            steps {
                // here just check the up stream doesn't have any change
                // afterward if there are conflict was not be fixed, unit test will fail
                // otherwise it will continuous 
                sh 'git fetch -a'
                sh 'git merge origin/FrontEnd'
            }
        }

        stage('Build FrontEnd') {
            when {
                branch('FrontEnd*')
            }
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps {
                dir('SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    sh 'npm install npm'
                    sh 'npm install'
                    sh 'npm i -g @angular/cli'
                    sh 'ng build'
                }
            }
        }
        // Continuous Integrate BackEnd
        stage('Merge BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                sh 'git pull'
                sh 'git merge origin/BackEnd'
            }
        }

        stage('Build BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                dir('SomeWhereCinema.Backend') {
                    sh 'dotnet build'
                }
            }
        }
        // Continuous Test
        stage('Test BackEnd') {
            when {
                branch('BackEnd*')
            }
            agent any
            steps {
                // should be in the test project, not solution fold
                dir('SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
                    echo 'remove histiory test results'
                    sh 'rm -rf TestResults'
                    sh 'dotnet add package coverlet.collector'
                    sh "dotnet test --collect:'Xplat Code Coverage'"
                }
            }
            post {
                success {
                    echo '====++++Test BackEnd executed successfully++++===='
                    archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
                //                     publishCoverage(
                //                         adapters: [
                //                             istanbulCoberturaAdapter(
                //                                 path: "SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml",
                //                                 thresholds:[[
                //                                     failUnhealthy: true,
                //                                     thresholdTarget: 'Conditional',
                //                                     unhealthyThreshold: 80.0, // below 80%
                //                                     unstableThreshold: 50.0  // below 50%
                //                                 ]]
                //                             )
                //                         ],
                //                         checksName: '',
                //                         sourceFileResolver: sourceFile('STORE_LAST_BUILD')
                //                     )
                }
            }
        }
    }

    post {
        always {
            echo '====++++All stages finish++++===='
            deleteDir()
        }
        success {
            echo '====++++successfully++++===='
        }
        failure {
            echo '====++++failed++++===='
        }
    }
}
