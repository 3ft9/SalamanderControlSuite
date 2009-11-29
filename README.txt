Salamander Control Suite (SCS)
==============================

SCS is a utility to ease the use of VNC on large networks. I wrote it while working as a developer for a small(ish) company where a VNC server was installed on every desktop. Whenever the support guys needed to VNC to one of the machine they'd ask the user to get their IP. In most cases this turned into a 5 minute conversation and was a major waste of time and a real hassle for the users.

At the time I was just getting into C# in a big way and I set about writing a tool to solve this problem. SCS is the result. I had plans to take it to production quality after adding some bells and whistles with a view to either selling it or releasing the source. Unfortunately I've not been able to find the time, and I actually left that company nearly 3 years ago and no longer have any interaction with VNC. So I've decided to release the source anyway in case it's useful to anyone.

Features
--------

* Scan netblocks for servers
* Persistant host list
* Password cache
* Multiple simultaneous connections (MDI interface)

Note that the host list and password cache is stored in config.xml in plain text which makes it very insecure. This is far from ideal and securing that was high on the list of outstanding features.

Requirements
------------

* Visual Studio 2005 (might work with C# Express)
* One or more VNC servers to connect to

Todo
----

This list is not extensive and just covers the basics I thought would be needed before releasing it.

* Secure storage for the host list
* Configuration dialog for auto-scanning options
* Lots more testing

Credits
-------

* VNC Manager uses the VNC-Client for .NET project: http://dnvnccl.sourceforge.net/
* All other development by Stuart Dallas

License
-------

I'm putting this project into the public domain so you're free to do whatever you want with it. However, it would be great if you could send me an email and tell me what you're doing with it.

Stuart Dallas
August 3rd, 2007
stuart@stut.net