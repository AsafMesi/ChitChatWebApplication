
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
1) Download the source code in the following link: https://github.com/AsafMesi/ChitChatWebApplication.
<img width="671" alt="image" src="https://user-images.githubusercontent.com/92876036/170839880-c8348904-6ebd-4856-8df1-e25c2d649126.png">

2) Unzip it to a local folder and open it with VS, and inside this folder, right click this file and choose open with VS:
<img width="746" alt="image" src="https://user-images.githubusercontent.com/92876036/170840003-63d89064-2c12-4425-89b8-655c88d393a6.png">

3) Right click the solution explorer:
 <img width="776" alt="image" src="https://user-images.githubusercontent.com/92876036/170840062-67bdc3f2-e88e-43f6-9437-9b79f553b415.png">

4) Choose set-up project:
<img width="591" alt="image" src="https://user-images.githubusercontent.com/92876036/170840135-3d79c9f4-55bb-4c60-9ecd-8c01e99aab3c.png">

5) Choose Multiple startup project and change "ChitChatRatings" and "ChitChatWebApi" to start and click apply and then ok:
<img width="591" alt="image" src="https://user-images.githubusercontent.com/92876036/170840136-0d8c9aa7-35b8-4370-8283-4e2a02e85d8b.png">

6) Finally click start, and you should see those two windows appear:
<img width="953" alt="image" src="https://user-images.githubusercontent.com/92876036/170840198-30d19977-5fb5-4cd2-b25c-ce90b5c17461.png">

#### That's it for the server side, please do not close those windows until you finish using the app, you can minimize them.
Now, for the client side click the link attached at the top of the page and follow the instructions from there.

Have fun.
## Authors
Asaf Mesilaty, Dan Marom

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
![WhatsApp Image 2022-05-29 at 16 45 57](https://user-images.githubusercontent.com/92876036/170877713-fa3c6532-38e0-40d2-aa6d-e4ae4afca7c7.jpeg)

4) Choose multiple startup project and change "ChitChatRatings" and "ChitChatWebApi" to start and click apply and then ok:
![WhatsApp Image 2022-05-29 at 16 46 33](https://user-images.githubusercontent.com/92876036/170877755-138afb55-1ed1-45c2-a5f5-66baef194683.jpeg)

5) Run the project for the 1st time and you should see this error message:
![WhatsApp Image 2022-05-29 at 16 47 04](https://user-images.githubusercontent.com/92876036/170877791-8cc17996-1d25-4f93-beda-00c137746662.jpeg)

DO NOT PANIC, it's ok. Stop the current run:
![WhatsApp Image 2022-05-29 at 16 47 49](https://user-images.githubusercontent.com/92876036/170877810-de8c7dd6-f23a-401d-ba43-b42341ccc429.jpeg)

6) Re run the project for the 2nd time, and you should see those 2 screens again:
 ![WhatsApp Image 2022-05-29 at 16 48 10](https://user-images.githubusercontent.com/92876036/170877843-ac61d83d-2c2f-4652-9eaf-1aa7c081b03e.jpeg)
 
 Now you can proceed to client side set up, to save you time to search for the link at the top of the page, we added it again for you convenience:
 https://github.com/danmarom16/chit-chat#readme
