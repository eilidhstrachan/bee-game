VAR counter = 0
{counter == 0: ->Introduction | ->Intro_Completed}

=== Introduction ===
Hey there! I'm Flora. 
Nice to meet you! I don't know if the mayor told you in his letter, but I'm a florist. I'm pretty much an expert in flowers, so if you need any help with flower related stuff then I'm your gal. 
You're probably wondering; why haven't they sent Flora to go find the flowers hm? Well let me tell you, I have a terrible sense of direction! I already tried to go out looking for them but I got lost. 
Also I'm so busy trying to find ways to keep my business running just now. You're definitely the best person for the job! Hopefully you can solve why the bees disappeared in the first place as well as bringing them back...

So you're a detective, huh?
    + [Yeah!]
        Nice! Well, I hope you can help get the bees back, Bea has been awful stressed.
        Oh, and everyone else obviously.
        ++ [Bea?]
        Yeah, Beatrice! She's a beekeeper so naturally she's very stressed just now. 
        I'm so worried about her ... If you see her, tell her I said hi. Maybe I could bring her some flowers later...
        No, that would be weird right? Aha aha um... anyways, see you around!
        ~ counter = 1
        -> DONE
        ++ [I see.]
        We're all rooting for you!
        ~ counter = 1
        -> DONE
    + [How could you tell?]
        If I say because of the hat will you be offended? Haha.
        ~ counter = 1
    -> DONE

=== Intro_Completed ===
Hey, you ok?
I'm pretty sure the mayor was looking for you.
-> DONE
        