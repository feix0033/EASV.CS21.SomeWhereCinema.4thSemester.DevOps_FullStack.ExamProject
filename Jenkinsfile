pipeline {
  agent any
  stages {
    stage('Build FrontEnd') {
      agent {
        docker {
          image 'node:16-alpine'
          args '-p 3000:3000'
        }

      }
      when {
        branch 'FrontEnd*'
      }
      steps {
        dir(path: 'SomeWhereCinema.Frontend') {
          sh 'npm cache clean --force'
          sh 'npm cache verify'
          sh 'npm install npm'
          sh 'npm install'
          sh 'npm i -g @angular/cli'
          sh 'ng build'
        }

      }
    }

    stage('Build BackEnd') {
      agent any
      when {
        branch 'BackEnd*'
      }
      steps {
        dir(path: 'SomeWhereCinema.Backend') {
          sh 'dotnet build'
        }

      }
    }

    stage('Test BackEnd') {
      agent any
      when {
        branch 'BackEnd*'
      }
      post {
        success {
          echo '====++++Test BackEnd executed successfully++++===='
          archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
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
    }

    stage('Deliver to git') {
      steps {
        git(url: 'https://github.com/feix0033/EASV.CS21.SomeWhereCinema.4thSemester.DevOps_FullStack.ExamProject.git', branch: 'FrontEnd_Dev', poll: true)
      }
    }

  }
  environment {
    CI = 'true'
    DOTNET_ROOT = '/usr/bin/dotnet'
    PATH = "/usr/bin/dotnet:$PATH"
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
  triggers {
    pollSCM('* * * * *')
  }
}