INCLUDE globals.ink

Ok detective... To prove you're up to the task, I've got a favour to ask you.
You see, there was a big storm a while ago, probably around the time when the bees disappeared actually. What a funny coincidence! Anyways, our lovely town hall's stained glass window got badly damaged in the weather.
Luckily all the pieces are still intact, but no one's got round to fixing it yet. Do you think you'd be able to give it a go?
+ [Of course!]
    Wonderful!
    -> chosen ("yes")
+ [Not right now, sorry.]
    Oh ok. Give it a go when you're less busy, eh?
    -> chosen ("no")
=== chosen(choice) ===
~ decision = choice
-> END

