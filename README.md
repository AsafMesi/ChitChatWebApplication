
![Readme-logo](https://user-images.githubusercontent.com/92876036/165103657-3b21e78e-27db-4285-a503-7f6d207bb110.png)

# ChitChat

#### Like WhatsApp - But BETTER (way better)

## Installation and getting started
The installation process consists of 3 parts:
1) Server side set up
2) Client side set up - detailed in this link: https://github.com/danmarom16/chit-chat#readme
--------------------------------
### Note that the order MATTERS!
#### you must complete the server side set up first, then the ratings set up and only then proceed to client side set up.
----------------------------------

#### Server side Set-up:
* Download the source code in the following link: https://github.com/AsafMesi/ChitChatWebApplication.
<img width="671" alt="image" src="https://user-images.githubusercontent.com/92876036/170839880-c8348904-6ebd-4856-8df1-e25c2d649126.png">

* Unzip it to a local folder and open it with VS, and inside this folder, right click this file and choose open with VS:
<img width="746" alt="image" src="https://user-images.githubusercontent.com/92876036/170840003-63d89064-2c12-4425-89b8-655c88d393a6.png">

* Right click the solution explorer:
* <img width="776" alt="image" src="https://user-images.githubusercontent.com/92876036/170840062-67bdc3f2-e88e-43f6-9437-9b79f553b415.png">

* Choose set-up project:
<img width="591" alt="image" src="https://user-images.githubusercontent.com/92876036/170840135-3d79c9f4-55bb-4c60-9ecd-8c01e99aab3c.png">

* Choose Multiple startup project and change "ChitChatRatings" and "ChitChatWebApi" to start and click apply and then ok:
<img width="591" alt="image" src="https://user-images.githubusercontent.com/92876036/170840136-0d8c9aa7-35b8-4370-8283-4e2a02e85d8b.png">

* Finally click start, and you should see those two windows appear:
<img width="953" alt="image" src="https://user-images.githubusercontent.com/92876036/170840198-30d19977-5fb5-4cd2-b25c-ce90b5c17461.png">

#### That's it for the server side, please do not close those windows until you finish using the app, you can minimize them.
Now, for the client side click the link attached at the top of the page and follow the instructions from there.

##### Troubleshooting for the Server side set up
---------------------------------------------
If youv'e got the following error message:
![WhatsApp Image 2022-05-29 at 16 43 11](https://user-images.githubusercontent.com/92876036/170877368-3cbed999-4cfe-47c4-8102-154bce538ab0.jpeg)

That means that the ratings project does not load properly. To solve this problem, please do the following steps:
1) Remove the "ChitChatRatings" project:
![WhatsApp Image 2022-05-29 at 16 43 50](https://user-images.githubusercontent.com/92876036/170877471-6acc4a05-a03f-419d-9f74-861a1d37ded7.jpeg)

2)re-add it:
  2)a) Right click the solution explorer and navigate to Add->Existing source
![WhatsApp Image 2022-05-29 at 16 44 12](https://user-images.githubusercontent.com/92876036/170877483-69f6840f-cc50-4607-98c2-7ddc2fb0991c.jpeg)
  2)b) Choose this specific .csproj file.
![WhatsApp Image 2022-05-29 at 16 44 34](https://user-images.githubusercontent.com/92876036/170877490-4ba411e2-3c03-495d-adf3-64930a331b7d.jpeg)

Now you should see it below the Solution explorer, like that:
![WhatsApp Image 2022-05-29 at 16 45 26](https://user-images.githubusercontent.com/92876036/170877625-787e11df-acee-4d18-aaeb-157ea92533c5.jpeg)

3) Right click again on the Solution Explorer and left click the "Set Startup Project":


Have fun.
## Authors
Asaf Mesilaty, Dan Marom
