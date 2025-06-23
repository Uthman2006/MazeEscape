# MazeEscape - Player vs AI
This project is based on two-player maze game where human and AI comeptes against each other to reach the exit of a maze which is chosen randomly. The game is turn-based. Both players start from different corners of the maze and
and have to find a way out which is the common exit. First player to reach the exit wins.
The goal of this pproject is to implement two-palyer board game with basic pathfinding AI and a simple user interface.
AI in this project uses Breadth-First-Search algorithm. It checks all the directions first from current location and finds the shortest path to the exit. It uses queue t save the positions.
When you first run the game it leads you to the Menu where you should choose a maze. After that the game starts, and here are the controls for playing:
## Controls
<table>
    <thead>
        <tr>
            <th width="200">Keys</th>
            <th width="200" >Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Q</td>
            <td>Quits the game ( and ends the execution)</td>
        </tr>
        <tr>
            <td>R</td>
            <td>Restarts the game</td>
        </tr>
        <tr>
            <td>^ (Arrow Up) or W</td>
            <td>Moves up (along the y-axis to the positive side)</td>
        </tr>
        <tr>
            <td> v (Arrow Down) or S</td>
            <td> Moves down (along the y-axis to the negative side)</td>
        </tr>
        <tr>
            <td>< (Arrow Left) or A</td>
            <td>Moves left (along the x-axis to the negative side)</td>
        </tr>
        <tr>
            <td>> (Arrow Right) or D</td>
            <td>Moves right (along the x-axis to the positive side)</td>
        </tr>
    </tbody>
</table>