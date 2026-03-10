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







# High-level architecture overview
- The Following is a an Architcture Diagram about the scripts in this project:

![Unity Architecture](Doc/UnityArchtectureVRelax.png)


# What I have prioritised in 2–3 hours and why
### Time Management
- I started with pre-planning the project before I began with the development by setting up the following time table
- using **Agile** Methodology
- That was done to give me a clear idea of what the task at hand is and how to best approach the problem.

![Unity Architecture](Doc/TimeManagementDay1.png)
- Below are also the extra hours I have spent on the project to clean up drone code, other code and UI.
![Unity Architecture](Doc/TimeManagementDay2.png)

- The first hour I spent desiging and breaking down the requirements and priorties.
- Shown below is the brainstorming of all the requirements of the assignment.
![Unity Architecture](Doc/BrainstormPlanning.png)

- The rest of the hour I spent on designing aspects like the Drone behavior, type of Enviroment and Drone Movement ideas:
![Unity Architecture](Doc/BrainstormConcept.png)
### Now the fun begins; development. 
  #### 1
 - I have spent the first 30 minutes setting up the states of the Drone, Jobs, and injector setup, as they are core parts of the project.
  -**The Why=** The State part is important because all the codes refer to this. It is also the fastest to make.
  #### 2
 - The following hour I focused on making a future proof JobManagement system that hosts all the information of the jobs and is able to Get and Set the jobs.
 - **The Why=** This part is important because it is the fundation of the project and acts as the core system. Therefore, it needs to be future proof.
 - That includes the JobManager, Job, Drone, and JobAssigment scripts.
 - The following 30 minutes I spent on UI programming by using MVVM method scripts. I expanded on it the next day.
 - At the beginning, the UI only had text which was later connected to the Jobs' and Drones' status.
 - #### 3 
 - The last hour I spent programming the DroneMovement and programmed it to avoid obstacles, so I used one line Raycast in front of the Drone. (later I changed it to a sphere Raycast because it was better for this situation)
- Then I placed all the enviroment parts and enviroment assets. (I made a simple environment by using pre-existing shapes in Unity to save time)
- **The Why** Focusing on the drone programing will tie the whole system together and make it runable even if it didn't look pretty. That is why I spent an extra 30 minutes just to fix the UI and the enviromental placement.
  #### Extra Time
- The goal was to have a deliverable that funtions in 3 hours. This was accompplished. I kept coming up with ideas and I had some time the day after, so I started optimizing the Drone Movement.
- I also spent and extra hour adding FPS viewer and cleaning up the code.
- In total it was 2 extra hours of development and debugging.
# What I would improve with more time 
- Focus on making the JobManager and JobAssignment code more flexible and easier to add features.
- Add comments with information in the code to help clarify what each function does.
- Focus on optmizing the drone movement to make it smoother. Test out NavMesh Agent with a hybrid system. Navmesh Deals with the pathing, and the DroneMovement would deal with altitude and obstacles.
- Allow the Drone to deal with delivering to different floors and travel over stairs.
- Make a house design, either through Blender 3D modeling or placement of Unity blocks.
- Make an UI that is more user friendly and easier to navigate.
