#  - How to run
##  - Run The Project 
- Open the link in a new tab.
- [Download GameToTest](GameToTest.zip)
- On the top right, click on the download button (Download Raw File).
- This file includes the executable of the playable Drone Assignment.
- Once downloaded open or extract the file.
- Then open **'VRelax Drone Assignment'**.

##  - Dependencies 
 Using Zenject (Extenject) as a Dependency Injector	
- The Project files should automatically be imported as Dependacy. If not, please import through this link:
- Link :  https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735 

##  - Run The Unity File

- Using Unity 6 version 6000.3.10f1
- Click on the button 'Code' on top to download the repository.
- Click on 'Download ZIP' and extract the ZIP file.
- Navigate to Unity HUB.
- Press on 'Projects' if you have the latest Unity Hub and then on the top right press 'Add'.
- Choose 'Add Project from disk'.

#### If all went well, you can now explore my work.







# High-level architecture overview (diagram or text)
- The Following is a an Architcture Diagram about the scripts in this project:

![Unity Architecture](Doc/UnityArchtectureVRelax.png)

- 

# What I have prioritised in 2–3 hours and why
### Time Management
- I have started with preplanning the project before I would start with development by setting up the following Time table
- using **Agile** Methodology
- That is to give me a clear idea of what is the task at hand and best approuch to takle it =

![Unity Architecture](Doc/TimeManagementDay1.png)
- The following is also extra hours I have spent on the project to clean up code and UI and especially the Drone Code
![Unity Architecture](Doc/TimeManagementDay2.png)

- The first hour I have spent Desiging and breaking down Requirment and Priorties.
- Shown below is the Brainstorming of all the Requirments of the Assignment.
![Unity Architecture](Doc/BrainstormConcept.png)
- Rest of the hour I have spend Designing aspects like the Drone behavior, type of Enviroment and Drone Movement ideas:
![Unity Architecture](Doc/BrainstormPlanning.png)
### Now the Fun Begins, Development. 
  #### 1
- I have set the first 30 mins setting up the states of the Drone and Jobs and injector setup as they are core essential part of the project.
  -1-**The Why=** The State part is important because all the codes will look at the state of the drone and the job and it is also the fastest to make.
  #### 2
 - The following hour I have focused on making a future proof Jobmanagement system that hosts all the information of the jobs and
 - able to Get and set the jobs.
 - **The Why=** this part is important because it is the fundation of the Project and act as the code system. Therefore, it needs to be future proof
 - that includes JobManager, Job, and Drone script and Job Assigment script.
 - The following 30 mins I have spent on UI Programming using simple MVVM method script. I have expanded on it the following day.
 - At the begening the UI only had text and that text later was connected with the Jobs and Drones
 - #### 3 
 - The last hour I have spend Programming the Drone movemet and setting it up to avoid obsticals, so I used simple Raycast infront of the Drone. (later I Remembered that sphere  Raycast is better for this situation)
- then I have placed all the enviroment parts and enviroment assets. ( I went simple on the environment by using preexisting shapes in unity to save time)
- **The Why** focusing on the drone Programing will tie the whole system together and make it runable even if it didnt look pretty. thats why i spent an extra 30 mins just to fix the UI and the Enviromental placement.
  #### Extra Time
- The Goal is to have a deliverable that funtions in 3 hours ( that was checked). I kept coming up with ideas, so I had some time the day after and I started optimizing the Drone Movement.
- also spent and extra hour adding FPS viewer and cleaning up the code.
- in total it was 2 extra hours over development of adding and cleaning up
# What I would improve with more time 
- Focused on making the JobManager and Job Assignment code more flexable and easier to add features.
- Add comments information in the code to help clearfy what each function does.
- Fucosed on Optmizing the drone movement make it smoother. test out NavMesh Agent with a hypred system, Navmesh Deals with the pathing, and the DroneMovement would deal with altitude and obsticals.
- Allow the Drone to deal with delivering to different floors and travel over stairs.
- Clean Up the UI. Make the UI has preplaned in the Conception session.
- Make a house design, either through Blender 3D modeling or placement of unity blocks.
- Make a UI that is more User friendly and easy to navigate.
