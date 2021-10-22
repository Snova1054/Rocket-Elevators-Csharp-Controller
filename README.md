# Rocket-Elevators-Csharp-Controller
## Description

This controller's whole purpose is to handle a personalized amount of elevators with a personalized amount of floors in a personalized amount of columns in a battery. 

It can be controller from any floor from the outside of the elevators, but mainly in the lobby. 

When used from the lobby, the battery choose the column that serves the floor selected by the user and then sends the best elevator possible for that spec floor and direction. Then, when used from the inside of the elevator that was selected by the column, the elevator is moved to the to the user's destination.

Otherwise, when called from another floor than the lobby, the column selects again the best elevator possible 

Elevator selection is based on the elevator's status, current floor, direction and floor request list and on the user's floor and direction.

## Dependencies

As long as you have **.NET 5.0** installed on your computer, nothing more needs to be installed:

The code to run the scenarios is included in the Commercial_Controller folder, and can be executed there with:

`dotnet run <SCENARIO-NUMBER>`

### Scenario 1

For the column B(2)
- Elevator A is on the 20th floor going down to the 5th floor.
- Elevator B is on the 3rd floor going up to the 15th floor.
- Elevator C is on the 13th floor going down to the 1st floor.
- Elevator D is on the 15th floor going down to the 2nd floor.
- Elevator E is on the 6th floor going down to the 2nd floor.

- User is on the 1st floor and wants to go to the 20th floor. Elevator E should be sent.

### Scenario 2

For the column C(3)
- Elevator A is stopped on the 1st floor but going up to the 21st floor.
- Elevator B is on the 23rd floor going up to the 28th floor.
- Elevator C is on the 33rd floor going down to the 1st floor.
- Elevator D is on the 40th floor going down to the 24th floor.
- Elevator E is on the 39th floor going down to the 1st floor.

- User is on the 1st floor and wants to go to the 36th floor. Elevator A should be sent.

### Scenario 3

For the column D(4)
- Elevator A is on the 58th floor going down to the 1st floor.
- Elevator B is on the 50th floor going up to the 60th floor.
- Elevator C is on the 46th floor going up to the 58th floor.
- Elevator D is on the 1st floor going up to the 54th floor.
- Elevator E is on the 60th floor going down to the 1st floor.

- User is on the 54th floor and wants to go back to the 1st floor. Elevator A should be sent.

### Scenario 4

For the column A(1)
- Elevator A is idle on the B4th floor.
- Elevator B is idle on the 1st floor
- Elevator C is on the B3rd floor going down to the B5th floor.
- Elevator D is on the B6st floor going up to the 1st floor.
- Elevator E is on the B1st floor going down to the B6th floor.

- User is on the 3rd floor and wants to go to the 1st floor. Elevator D should be sent.

## Running the tests

To launch the tests, make sure to be at the root of the repository and run:

`dotnet test`

With a fully completed project, you should get an output like:

![Screenshot from 2021-06-15 17-31-02](https://user-images.githubusercontent.com/28630658/122128889-3edfa500-ce03-11eb-97d0-df0cc6a79fed.png)

You can also get more details about each test by adding the `-v n` flag: 

`dotnet test -v n` 

which should give something like: 

![Screenshot from 2021-06-15 18-00-52](https://user-images.githubusercontent.com/28630658/122129140-a8f84a00-ce03-11eb-8807-33d7eab8c387.png)
