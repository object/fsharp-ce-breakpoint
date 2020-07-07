module ActorTests

open Akka
open Akkling
open Xunit

open Actors

[<Fact>]
let ``Send message`` () =
        
    let akkaConfig = Configuration.parse ("akka { loglevel = DEBUG }")
    let system = System.create "system" <| akkaConfig
    
    let debugActor1 = spawnAnonymous system (props TestActor.debugActor1)
    debugActor1 <! TestActor.Anything
    
    let debugActor2 = spawnAnonymous system (props TestActor.debugActor2)
    debugActor2 <! TestActor.Anything
