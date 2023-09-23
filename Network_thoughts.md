# Network?

## Architecture/connection details
Arch: Authoritative peer with no authority shifting (too hard for game jam)
Connection: Direct IP with port

## RPC / messaging needs
* Player cursor position change
* Player requested tile placement 
* Game state update (board, scores, game phase, time sync)
* Player Joined (basic may be automatic? Definitely needs augment)


## Server side responsibilities
* Calculating score on tick
* Receiving, handling, and approving tile placements
* Controlling game state and game state change requests
* Start new game with same players? Hmmm

## Server/local shared responsibilities? 
**(Should we just have "local" be the server with networking disconnected?)**
* Calculating
* Receiving 
