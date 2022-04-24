INCLUDE BookPuzzleVariables.ink

Ok, I'm just gonna assume you've seen the book now. The cover says "A Wizard's Guide To Magic" on it! Why would someone just leave that out in the open? Magic books are very hard to come by. 
Maybe whoever it belongs to forgot about it?
Anyways, there's a page ripped out right? Well, I found a bunch of ripped up pieces of paper beside the bin! What if they're from the missing page?
So, do you wanna help me try and put it back together?
+ [Of course!]
    Alright! We can do it, detective.
    -> chosen ("yes")
+ [Maybe later.]
    Ok, but I think this could be really important!
    -> chosen ("no")
=== chosen(choice) ===
~ decision = choice
-> END
