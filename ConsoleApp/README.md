# ConsoleApp
Spreetail demo console app


this is straight forward console application, where it takes user entry of key and value to add to dictionary. 

given use case was:
		KEYS
		 ADD foo bar
		) Added		--- after added immediately KEYS are not listing , so i belive we need user to able to select the options 
		> ADD baz bang
		) Added
		> KEYS    ----PRESS 1 option to see KEYS
		1) foo
		2) baz


after each transaction, I have added a feature of below option(on top and selection on each transaction) to give user the flexibilty what they want to do next.

What you want to do next?
        0=ADD
        1=KEYS
        2=MEMBERS
        3=REMOVE
        4=REMOVEALL
        5=CLEAR
        6=KEYEXISTs
        7=MEMBEREXISTS
        8=ALLMEMBERS
        9=ITEMS
please choose an option from above:

so if you want to ADD enter 0;

EXAMPLE: 
			What you want to do next?
			        0=ADD
			        1=KEYS
			        2=MEMBERS
			        3=REMOVE
			        4=REMOVEALL
			        5=CLEAR
			        6=KEYEXISTs
			        7=MEMBEREXISTS
			        8=ALLMEMBERS
			        9=ITEMS
			please choose an option from above: 0
			> ADD

use cases:

============== KEYS ===========================================
please choose an option from above: 0
> ADD  foo bar
) Added

please choose an option from above: 0
> ADD  baz bang
) Added

please choose an option from above: 1
> KEYS
1)foo
2)baz

================ MEMBERS =====================================
please choose an option from above: 0
> ADD  foo bar
) Added

please choose an option from above: 0
> ADD  foo baz
) Added

please choose an option from above: 2
> MEMBERS foo
1)bar
2)baz

please choose an option from above: 2
> MEMBERS bad
) ERROR , Key does not exist

======================== ADD ====================================
please choose an option from above: 0
> ADD  foo bar
) Added

please choose an option from above: 0
> ADD  foo baz
) Added

please choose an option from above: 0
> ADD  foo bar
) ERROR , Member already exist for key
======================== REMOVE ====================================please choose an option from above: 0
> ADD  foo bar
) Added

please choose an option from above: 0
> ADD  foo baz
) Added

please choose an option from above: 3
> REMOVE foo bar
Removed

please choose an option from above: 3
> REMOVE foo bar
) ERROR, Member does not exist

please choose an option from above: 1
> KEYS
1)foo

please choose an option from above: 3
> REMOVE foo baz
Removed

please choose an option from above: 1
> KEYS
(empty set)

please choose an option from above: 3
> REMOVE boom pow
) ERROR, key does not exist

======================== REMOVE ALL====================================
please choose an option from above: 0
> ADD  foo bar
) Added


please choose an option from above: 0
> ADD  foo baz
) Added


please choose an option from above: 1
> KEYS
1)foo


please choose an option from above: 4
> REMOVEALL foo
) Removed


please choose an option from above: 1
> KEYS
(empty set)


please choose an option from above: 4
> REMOVEALL foo
) ERROR, key does not exist

======================== CLEAR ====================================
please choose an option from above: 0
> ADD  foo bar
) Added


please choose an option from above: 0
> ADD  bang zip
) Added


please choose an option from above: 1
> KEYS
1)foo
2)bang


please choose an option from above: 5
> CLEAR 
) Cleared
(empty set)


please choose an option from above: 1
> KEYS
(empty set)


please choose an option from above: 5
> CLEAR 
) Cleared
(empty set)


please choose an option from above: 1
> KEYS
(empty set)

======================== KEYEXISTS ====================================
please choose an option from above: 6
> KEYEXISTS foo
) false


please choose an option from above: 0
> ADD  foo bar
) Added


please choose an option from above: 6
> KEYEXISTS foo
) true

======================== MEMBEREXISTS ====================================
please choose an option from above: 7
> MEMBEREXISTS foo bar
) false


please choose an option from above: 0
> ADD  foo bar
) Added


please choose an option from above: 7
> MEMBEREXISTS foo bar
) true


please choose an option from above: 7
> MEMBEREXISTS foo baz
) false

======================== ALLMEMBERS ====================================
please choose an option from above: 8
> ALLMEMBERS
(empty set)

please choose an option from above: 0
> ADD  foo bar
) Added


please choose an option from above: 0
> ADD  foo baz
) Added


please choose an option from above: 8
> ALLMEMBERS
 1)bar
 2)baz


please choose an option from above: 0
> ADD  bang bar
) Added


please choose an option from above: 0
> ADD  bang baz
) Added


please choose an option from above: 8
> ALLMEMBERS
 1)bar
 2)baz
 3)bar
 4)baz

 ======================== ITEMS ====================================
 please choose an option from above: 9
> ITEMS
 (empty set)


please choose an option from above: 0
> ADD  foo bar
) Added


please choose an option from above: 0
> ADD  foo baz
) Added


please choose an option from above: 9

 0) foo: bar
 1) foo: baz

please choose an option from above: 0
> ADD  bang bar
) Added


please choose an option from above: 0
> ADD  band baz
) Added

please choose an option from above: 9

 0) foo: bar
 1) foo: baz
 2) bang: bar
 3) band: baz