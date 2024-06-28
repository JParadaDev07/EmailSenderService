# EmailSenderService

- [EmailSenderService](#emailsenderservice)
  - [What is this?](#what-is-this?)
  - [Things to bear in mind](#things-to-bear-in-mind)
    - [How to use it?](#how-to-use-it)
      - [Request](#request)
      - [Response](#response)
      - [Error Response](#error-response)
      - [Final step](#final-step)

## What is this

EmailSenderService is an application designed to emulate the sending of emails in a simplified way. It aims to provide a basic experience similar to that provided by large email companies, albeit on a much smaller scale and with an educational approach. This service is fully functional and handles specific errors, thus providing a solid foundation for understanding the principles that govern the sending of emails in modern applications.

## Things to bear in mind

- The application is designed to be a simplified version of a real email sender, so it does not have all the features that a real email sender has, but it has the basic features to understand how an email sender works.

- If you want to modify the application, you can do it without any problem, the application is designed to be modified and to be used as a base for a more complex application.

- The structure of the application is not based on any architecture, so you can use the architecture that you want, and you can modify the application to use the architecture that you want.

- This application is not designed to send any kind of attachment, so you can send only text emails (For now).

## How use it?

- First of all, this application does not have any kind of authentication, so you can use it without any problem and at your own risk.

- The application needs to know the email address of the sender, to do that, you will need to get in into the code, and modify one simple file, and this will be the appsettings.json, where you can find the following code:

```json
{
  "EmailSettings": {
    "MailServer": "smtp.gmail.com",
    "MailPort": 587,
    "Email": "youremail@example.com",
    "Password": "yourpassword"
  }
}
```

**For convenience, don't use your personal account, you could create a recipient account or use one in which you do not have sensitive or very personal data.**

>MailServer: This is already configured by default to use the gmail server, so you don't have to modify this field.

>MailPort: This is already configured by default to use the port 587, so you don't have to modify this field.

>Email: This is the email address that will be used to send the emails, so you will need to modify this field with your email address.

>Password: This is the password of the email address that will be used to send the emails, so you will need to modify this field with your email password.

- **Important:** You will need to config your account to allow less secure apps to access your account, follow this steps to do it: [Allow less secure apps to access your account](#allow-less-secure-apps-to-access-your-acount)

#### Allow less secure apps to access your acount

1. Go to your Google Account using this link https://myaccount.google.com

2. On the left navigation panel, click Security.

3. You will scroll down to the How to access Google data section, and then click on Two-step verification.

4. Automatically, you will be redirected to the login page, so you will need to log your password again, only to verify that you are the owner of the account.

5. After this, you will need to put your phone number, and then you will receive a code to verify your phone number.

6. After verifying your phone number, you will need to enable the two-step verification.

7. After enabling the two-step verification, you will need to go back to the Security section, and then scroll down again to the How to access Google data section, and then click on App passwords.

8. Again, you will be redirected to the login page, so you will need to log your password.

9. After this, you will need to select the app and the device you want to generate the app password, you will choose the **Other** option on the Select app dropdown, and then you will write the name of the device you want to generate the app password.

10. After this, you will click on the Generate button, and then you will receive a password, this password is the one that you will use in the appsettings.json file, most specifically in the Password field.

11. If all the credentials on the appsettings.json file, are correct, you will can use the app without any problem.

- **Note:** If you want to use another email provider, you will need to modify the MailServer and MailPort fields, with the corresponding values of your email provider.

* After you have configured the appsettings.json file, you will need to run the application, **The application is configured, to run without Swagger, so you will need to use Postman or any other tool to test the application.** fortunately, if your'e using Visual Studio Code, on the root of the project, you will find a folder called Requests, inside of this folder, you will find a file called EmailSenderRequest.http, that contain the necessary request to test the application, but you will need to chanche the host variable configured in the file, with the port that the application is running.

```js
POST "http://yourlocalhost"
```

### Request

- The application has only one endpoint, and this is the /api/send-email, this endpoint receives a POST request, and the body of the request must be a JSON object with the following structure:

```json
{
  "to": "examplemail@mail.com",
  "subject": "This is the subject of the email",
  "body": "This is the body of the email"
}
```

### Response

- And if the email is sent successfully, the application will return a response with the following structure:

```js
200 OK
```

```json
{
  "to": "the email address of the recipient",
  "message" : "This is the message that returns the application"
}
```

> The application only will return the email address of the recipient and a message that the email was sent successfully. 

### Error Response

- If there's an error, the application will return a response, for example, if the email structure is not correct, the application will return a response with the following structure:

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "The email address is invalid.",
  "status": 400,
  "traceId": "00-e99858f7b3d2399878593a9bdbe88896-5c8956cd6f3d7102-00",
  "errorCodes": ["Email.Invalid"]
}
```

> The structure of the error response is pulled from the ErrorOr Library, look the code of the creator over here: https://github.com/amantinband/error-or. The beauty of this library is that it allows you to create a more complex error response, create your errorCodes, and create a more detailed error responses. **If you want to see the syntax of the errors, you can navigate to the root of the project, look in the Entities folder and inside this folder you will find another folder, called Errors, inside this folder you can find the structure of the custom errors, their error codes and more**.

> If you get into the link of the type field, you will find a more detailed explanation of the error.

## Final step

- That's all, this service is probably very simple, but it is designed to be simple, so you can understand how an email sender works.
