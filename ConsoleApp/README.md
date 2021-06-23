# ConsoleApp
Spreetail demo console app


this is straight forward console application, where it takes user entry of key and value to add to dictionary. 

command can be in uppercase or lowercase
EXAMPLE: 
	ADD foo bar
	or
	add foo bar

tested use cases:

============== KEYS ===========================================
> ADD foo bar
) Added


> ADD baz bang
) Added


> KEYS
1)foo
2)baz

================ MEMBERS =====================================
> ADD foo bar
) Added


> ADD foo baz
) Added


> MEMBERS foo
1)bar
2)baz


> MEMBERS bad
) ERROR , Key does not exist

======================== ADD ====================================
> Add foo bar
) Added


> add foo baz
) Added


> add foo bar
) ERROR , Member already exist for key
======================== REMOVE ====================================
> Add foo bar
) Added


> add foo baz
) Added


> remove foo bar
Removed


> remove foo bar
) ERROR, Member does not exist


> keys
1)foo


> remove foo baz
Removed


> keys
(empty set)


> remove boom pow
) ERROR, key does not exist

======================== REMOVE ALL====================================
> add foo bar
) Added


> add foo baz
) Added


> keys
1)foo


> removeall foo
) Removed


> keys
(empty set)


> removeall foo
) ERROR, key does not exist

======================== CLEAR ====================================
> add foo bar
) Added


> add bang zip
) Added


> keys
1)foo
2)bang


> clear
) Cleared
(empty set)


> keys
(empty set)


> clear
) Cleared
(empty set)


> keys
(empty set)

======================== KEYEXISTS ====================================
> KEYEXISTS foo
) false


> add foo bar
) Added


> keyexists foo
) true

======================== MEMBEREXISTS ====================================
> MEMBEREXISTS foo bar
) false


> ADD foo bar
) Added


> memberexists foo bar
) true


> memberexists foo baz
) false

======================== ALLMEMBERS ====================================
> ALLMEMBERS
(empty set)


> ADD foo bar
) Added


> ADD foo baz
) Added


> ALLMEMBERS
1)bar
2)baz


> ADD bang bar
) Added


> ADD bang baz
) Added


> ALLMEMBERS
1)bar
2)baz
3)bar
4)baz

 ======================== ITEMS ====================================
> ITEMS
 (empty set)


> ADD foo bar
) Added


> ADD foo baz
) Added


> ITEMS
0) foo: bar
1) foo: baz


> ADD bang bar
) Added


> ADD bang baz
) Added


> ITEMS
0) foo: bar
1) foo: baz
2) bang: bar
3) bang: baz