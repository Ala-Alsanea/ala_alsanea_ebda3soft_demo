(TODO)

rework the unit of work pattern
async / await / tasks<> / cancelation token
fix project logic

-----------------------------------------------------------------------------------------------------------------------
(BASICS LEARNING)

files handling
time provider
localization
http client
testing
CQRS pattern / result pattern / mediator / fluent-validation / pipeline pattern / features pattern / DDD

addscope
addtransient
addsingleton
assmply / options / configuration
WebApplication / IHostedService / IHost / Builder / configuration

multi project single repository
docker advance:
    docker file / docker compose
    deployment
    orchestration
    kubernetes
git advance
    commands
    ssh
    branches manipulation
    modules

-----------------------------------------------------------------------------------------------------------------------
(ADVANCE LEARNING)

Modular Monolith
REPR pattern / Decorator pattern / Outbox pattern / Top Security pattern
Load Balancer / API gateway
API gateway with gRPCs
aspire 
saga
API Idempotent / HATEOAS
EF Core:
    multitenancy 
    aggregate  
    grouped classes for fluent api EF Core
    indirect many-to-many relationships
    projection using
    tracking
    raw sql
    generate sql scripts
    working with an existing database
    stored procedures
    transactions
    triggers
    optimization

-----------------------------------------------------------------------------------------------------------------------
(LISTS)

project:
    a post has one header
    a post has one author
    an author has many posts
    a post has many categories
    a category has many posts

urls:
    https://www.youtube.com/watch?v=8vTCyhDyRjg&list=PL82C6-O4XrHfZoh2ZH7-HCPyh9oHeYPnz
    https://www.youtube.com/watch?v=_8nLSsK5NDo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0
    https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code
    https://www.youtube.com/results?search_query=+Milan+Jovanovi%C4%87

tools:
    vs code / vs community 2022
    .net core sdk / .net core runtime
    sql server
    sql server management studio
    insomnia
    docker
    (dotnet runtime) development kit -v7
    (dotnet sdk) development kit -v8
    (c#) programming language
    (asp.net core) framework
    (nuget) package distributor
    (dotnet cli) dependency manager

install:
    setup tools: .net sdk/runtime / git / git ignore / sql server / sql server management studio / insomnia / vs code OR vs community 2022
    test sql server connection / get connection string
    create a new project folder
    >>dotnet new globaljson
    configure the globaljson
    >>dotnet new webapi -o
    >>dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    >>dotnet add package Pomelo.EntityFrameworkCore.MySql
    >>dotnet add package Microsoft.EntityFrameworkCore.Design
    >>dotnet add package Microsoft.EntityFrameworkCore.Tools
    >>dotnet add package Microsoft.EntityFrameworkCore
    >>dotnet tool install --global dotnet-ef
    setup models for implicit migrations / setup db context for explicit migrations / annotations / fluent api
    >>to create a new migration file: dotnet ef migrations add {MigrationName} --context {ContextClassName}
    >>to list migrations: dotnet ef migrations list --context {ContextClassName}
    >>to update a migration: dotnet ef database update {MigrationName} --context {ContextClassName}
    >>to delete the last migration file: dotnet ef migrations remove --context {ContextClassName}
    setup seed class
    >>dotnet run seed-data
    >>dotnet run

program.cs:
    using PostApi.Application;
    // application start (framework)
    var builder = WebApplication.CreateBuilder(args);
    // initialize configuration (application)
    var config = Config.Boot(builder);
    // application build (framework)
    var app = config.Build();
    // initialize CLI (application)
    Cli.Boot(app, args);
    // initialize bootstraping (application)
    var bootstrap = Bootstrap.Boot(app);
    // application run
    bootstrap.Run();

core:
    clean architecture
        domain
        application
        infrastructure
        presentation
    testing
    debugging
    config.json
    deployment / hosting / docker
    optimization
    localization
    security and auditing
    logging
        output
        type
        calling
    packages
    console commands / custom commands
    configuration
    frontend assets and integration
    folder structure / infrastructure
    mvc
    code-base
    features

api:
    routes
    middlewares
    requests
    validation
    controllers
    api logic
        architecture
            global services 
            repositories / queries / model / unit of work / context
            etc..
    responses
    dtos
        input
            User-Agent
            url
            ip
            query parameters
            path parameters
            headers
            body
                multiform
                json
        output
            json
                exceptions / domain errors
                cache
                pagination
                rate limit

code-base:
    stateful
    DI
    interfaces
    enums / constants
    utils
        methods
    support
        classes
    events / listeners
    file system
    http client

features:
    authentication
        user
            id
            roles
            account (multi / single)
                normal
                    email
                    password
                    phone number
                    username
                provider / provider id
                    facebook 
                    google
                    twitter
                    etc..
            profile (multi / single)
                name
                gender
                bio
                location
                etc..
        actions
            register
                validation
                assert email / phone number does not exist
                generate username
                hash password
                create user
                generate token
                send email / sms
                return user payload (user / token)
            delete account
                password confirmation
                delete user after 30 days
            login
                validation
                assert email / phone number / username does exist
                validate password
                check user status
                generate token
                return user payload (user / token)
            logout
                revoke token
            forgot password (email service)
                if user exists continue else cancel
                if user got reset password email then check if
                user email is verified
                user did not used social login
                user has no strikes
                user is not blocked
                then reset password email is sent to user
                if reset password email was sent to user then check if
                email exists
                reset password request exists
                reset password request attempts is less than the maximum allowed attempts
                reset password request code is valid
                reset password request is not expired
                then send a token to reset password
                if token was sent to user then check if
                token and code and email are valid
                reset password request is not expired
                user exists
                new password is different from old password
                then update password
            email verification (email service)
                if email is null then verify the current email
                check if user has already used social login or already verified then cancel
                else send a verification email
                if email is not null then verify the new email
                check if user has already used social login then cancel
                else send a verification email
                if user received the email then check if
                verify email request not found then cancel
                email verification code has expired then cancel
                else verify the email by updating the user email and email_verified_at field
            phone number verification (OTP service)
                if phone is null then verify the current phone
                check if user has already used social login or already verified then cancel
                else send a verification OTP
                if phone is not null then verify the new phone
                check if user has already used social login then cancel
                else send a verification OTP
                if user received the OTP then check if
                verify phone request not found then cancel
                phone verification code has expired then cancel
                else verify the phone by updating the user phone and phone_verified_at field
            update account details
                update email
                update phone number
                update password
            update profile details
                update info
            manage sessions
                list sessions
                delete session
            account audit / logs
            provider: login / register / link / unlink
            2FA / keypass / 2 step verification
            password / 2FA confirmation
            manage firebase
            privacy page / terms page / help page / about page / contact page / etc..
    authorization
        roles
        permissions
        policies
        custom authorization system requirements
    app settings
    background tasks
    queues
    processing
    subscriptions
    mails / notifications
    files handling
    health checks
    webhooks
    api gateway
    grpc
    message broker
    polling / websockets
    etc..