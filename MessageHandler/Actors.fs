namespace Actors

open Akkling

module TestActor =
        
    type Anything = Anything
        
    let debug msg = printfn "%A" msg

    let debugActor1 (mailbox:Actor<Anything>) =
        let rec loop () =
            actor {
                let! msg = mailbox.Receive ()
                return!
                    match msg with
                    | Anything ->
                        printfn "Doesn't stop here"
                        loop ()
            }
        loop ()

    let debugActor2 (mailbox:Actor<Anything>) =
        let rec loop () =
            actor {
                let! msg = mailbox.Receive ()
                return!
                    match msg with
                    | Anything ->
                        debug "Doesn't stop here"
                        printfn "Stops here"
                        loop ()
            }        
        loop ()

    let debugActor3 (mailbox:Actor<Anything>) =
        let rec loop () =
            actor {
                let! msg = mailbox.Receive ()
                return!
                    match msg with
                    | Anything ->
                        printfn "Doesn't stop here"
                        printfn "Doesn't stop here"
                        loop ()
            }        
        loop ()
