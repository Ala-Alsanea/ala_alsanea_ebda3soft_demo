

# Setup with docker

1. must have good internet connection.

1. install docker and docker-compose to your machine :
    1. for windows [here](https://docs.docker.com/desktop/install/windows-install/).
    1. for linux [here](https://docs.docker.com/desktop/install/linux-install/).

1.After installing docker, run `docker-compose up --build` in the root directory of the project in terminal. 
    1. this with install all the dependencies and run the application in the docker container with SqlServer DB container.

1. then navigate to `http://localhost:8080` in your browser.

# Teck Stack
1. Asp.Net 8 MVC
1. Entity Framework Core
1. SqlServer
1. Docker
1. Bootstrap 5
1. Razor Pages


# How to use the application
1. first, create a user to access the application.
1. the entity is listed in the top navigation bar.

## Note
1. All progress is saved in git commits.
1. Database is a docker image of SqlServer.
1. Database dose not have any data in it.
1. the User entity is used to be an auth entity.
1. the account entity is used to be linked with another entity for demonstration purposes.
1. github repo [here](https://github.com/Ala-Alsanea/ala_alsanea_ebda3soft_demo)
1. Send sms is implemented in ./Controllers/AccountController.cs
```dotnetcli
        public ActionResult Sms()
        {
            const string accountSid = "your_account_sid";
            const string authToken = "your_auth_token";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello from ASP.NET MVC!",
                from: new Twilio.Types.PhoneNumber("+1234567890"), // Your Twilio number
                to: new Twilio.Types.PhoneNumber("+0987654321") // Account's number
            );

            return Content($"Sent message: {message.Sid}");
        }
```
