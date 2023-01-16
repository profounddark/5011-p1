# Object-Oriented Concepts P1

## Part I: Class Design (jumpPrime.cs)

Each jumpPrime object encapsulates a positive integer, which must be at least 4-digits long, and yields the prime numbers closest to that number. For example, an active jumpPrime myObj that encapsulates 2488:

```
  myObj.up();   // returns prime number 2503
  myObj.down();  // returns prime number 2477
```

Additionally, the encapsulated number will ‘jump’ after a limited number of queries, a number determined by the distance between the two closest prime numbers. Hence, the active jumpPrime myObj that encapsulates 2488 will ‘jump’ to a value > 2503 or to a value < 2477 after 26 queries. Every jumpPrime object is initially active but transitions to inactive once the number of jumps exceeds a bound. The client may reset as well as revive a jumpPrime object. An attempt to revive an active jumpPrime object causes that object to be permanently deactivated.  
**Many details are missing. You MUST make and DOCUMENT your design decisions!!**
This assignment is an abstract realization of a data sink (store) that yields specific information upon query but can age and become invalid. With the interface described above, your design should encapsulate and control state as well as the release of information.

## Part II: Driver (P1.cs) -- External Perspective of Client -- tests your class design

Design a **FUNCTIONALLY DECOMPOSED** driver to demonstrate the program requirements.  
Use many distinct objects, initialized appropriately, i.e. random distribution of jumpPrimes, etc.  
Adequate testing requires varied (random) input sufficient enough to yield objects in different  
states and the seamless alteration of the state of some objects.  
Make your output readable but not exceedingly lengthy.
