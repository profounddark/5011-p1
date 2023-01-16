using System.Diagnostics;


class JumpPrime
{
    const uint DefaultJumpBound = 10;
    const uint DefaultInitialValue = 9999;
    const int DefaultJumpValue = 100;


    private uint _mainNumber;
    private bool _isRunning;
    private bool _isBroken;

    private uint _queryCount;
    private uint _queryLimit;

    private uint _jumpCount;
    private uint _jumpLimit;

    private uint _upperPrime;
    private uint _lowerPrime;

    /// <summary>
    /// isPrime determines whether or not the given positive integer is a prime number
    /// or not (i.e., a whole number greater than one that cannot be exactly divided by
    /// any whoel number other than itself)
    /// </summary>
    /// <param name="testNumber">the positive integer to be tested</param>
    /// <returns><c>true</c> if the number is prime, <c>false</c> otherwise</returns>
    private bool _isPrime(uint testNumber)
    {
        for (uint i = 2; i < testNumber; i++)
        {
            if (testNumber % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// setPrimeLimits finds a new upper and lower prime number based
    /// on the established stored number (<c>_mainNumber</c>).
    /// </summary>
    // PRECONDITION: A new _mainNumber has been set
    private void _setPrimeLimits()
    {
        _upperPrime = _findPrime(_mainNumber);
        _lowerPrime = _findPrime(_mainNumber, false);

    }

    /// <summary>
    /// resetQueryCounter sets the new query limits (based on the distance
    /// between the stored number (<c>_mainNumber</c>) and the next and previous
    /// prime number) and resets the query counter to 0.
    /// </summary>
    private void _resetQueryCounter()
    {
        // find greater of distance from the new value and set query limit
        if ((_upperPrime - _mainNumber) > (_mainNumber - _lowerPrime))
        {
            _queryLimit = _upperPrime - _mainNumber;
        }
        else
        {
            _queryLimit = _mainNumber - _lowerPrime;
        }

        // reset the query count
        _queryCount = 0;
    }

    /// <summary>
    /// jumpNumber "jumps" the value of the stored number, <c>_mainNumber</c>, by a specified
    /// amount. After a set number of "jumps", the <c>JumpPrime</c> will deactive.
    /// </summary>
    /// <param name="jumpValue">the value (positive or negative) to "jump" the stored
    /// number, <c>_mainNumber</c>, by.</param>
    private void _jumpNumber(int jumpValue)
    {

        _mainNumber = (uint)(_mainNumber + jumpValue);

        _setPrimeLimits();
        _resetQueryCounter();

        _jumpCount++;
        // test if at the jump limit and deactivate if necessary
        if (_jumpCount >= _jumpLimit)
        {
            _isRunning = false;
        }


    }

    /// <summary>
    /// finePrime finds either the next nearest prime number or the previous nearest
    /// prime number in sequence.
    /// </summary>
    /// <param name="startValue">the positive integer to start the search from</param>
    /// <param name="findNext"><c>true</c> to return the next prime number in sequence,
    /// <c>false</c> to return the previous prime number in sequence. Defaults to true.
    /// </param>
    /// <returns>the next or previous positive prime integer within bounds of the
    /// <c>uint</c> data type.
    /// </returns>
    private uint _findPrime(uint startValue, bool findNext = true)
    {
        sbyte stepValue = findNext ? (sbyte)1 : (sbyte)-1;

        uint result = (uint)(startValue + stepValue);

        while (!_isPrime(result))
        {
            result = (uint)(result + stepValue);
        }

        return result;

    }

    /// <summary>
    /// Initializes a new <c>JumpPrime</c> object to an initial value.
    /// </summary>
    /// <param name="initValue">the initial value to set the <c>JumpPrime</c> object to.
    /// Defaults to the class <c>DefaultInitialValue</c> value.</param>
    /// <param name="jumpBound">the bound for how many times the object will jump. Defaults to
    /// the class <c>DefaultJumpBound</c> value.</param>
    public JumpPrime(uint initValue = DefaultInitialValue, uint jumpBound = DefaultJumpBound)
    {
        // set that it isn't broken
        _isBroken = false;

        // sets the bound on number of jumps
        _jumpLimit = jumpBound;

        this.Reset(initValue);

    }


    /// <summary>
    /// Returns the next highest prime number from the number stored in the
    /// <c>JumpPrime</c> object. Does not return accurate results if the
    /// <c>JumpPrime</c> object has been deactivated.
    /// </summary>
    /// <returns>the next highest prime number, unless the <c>JumpPrime</c> object
    /// had been deactivated, in which case it returns 0.</returns>
    public uint up()
    {
        if (_isRunning)
        {
            if (_queryCount >= _queryLimit)
            {
                _jumpNumber(DefaultJumpValue);
            }
            _queryCount++;
            return _upperPrime;
        }
        return 0;
    }

    /// <summary>
    /// Returns the next lowest prime number from the number stored in the
    /// <c>JumpPrime</c> object. Does not return accurate results if the
    /// <c>JumpPrime</c> object has been deactivated.
    /// </summary>
    /// <returns>the next lowest prime number, unless the <c>JumpPrime</c> object
    /// had been deactivated, in which case it returns 0.</returns>
    public uint down()
    {
        if (_isRunning)
        {
            if (_queryCount >= _queryLimit)
            {
                _jumpNumber(-DefaultJumpValue);
            }
            _queryCount++;

            return _lowerPrime;
        }
        return 0;
    }


    /// <summary>
    /// Revive attempts to revive a disabled <c>JumpPrime</c> object. This resets the
    /// query and jump count and allows the object to be queried again. If the object is
    /// already active, it permanently disables the object (makes it irreparable).
    /// </summary>
    /// <returns>
    /// <c>true</c> if the attempt to revive was successful. <c>false</c> otherwise.
    /// </returns>
    public bool Revive()
    {
        // if the class is not running and not broken
        if (!_isRunning && !_isBroken)
        {
            // reactivate the class
            _isRunning = true;
            _jumpCount = 0;
            _queryCount = 0;
        }

        // in all other instances
        else
        {
            // Revive makes the object permanently irreparable (i.e., Broken)
            _isRunning = false;
            _isBroken = true;
        }

        return _isRunning;
    }

    /// <summary>
    /// Reset attempts to reset the <c>JumpPrime</c> object to a new integer value.
    /// This will fail if the new value is not at least a four digit positive integer
    /// or if the <c>JumpPrime</c> object was already made irreparable.
    /// </summary>
    /// <param name="newValue">the new four digit positive integer to be contained
    /// in the <c>JumpPrime</c> object.</param>
    /// <returns><c>true</c> if the reset is successful or <c>false</c> otherwise</returns>
    public bool Reset(uint newValue)
    {
        // object is already broken
        if (_isBroken)
        {
            return false;
        }

        // new reset value is less than 4 digits
        else if (newValue < 1000)
        {
            _isBroken = true;
            return false;
        }

        // all other cases, valid object and number
        else
        {
            _isRunning = true;
            _mainNumber = newValue;

            _setPrimeLimits();

            _resetQueryCounter();

            _jumpCount = 0;

            return true;
        }
    }

    /// <summary>
    /// IsActive returns whether or not the <c>JumpPrime</c> object has been
    /// deactivated due to excessive jumps.
    /// </summary>
    /// <returns><c>true</c> if the <c>JumpPrime</c> object is currently active,
    /// <c>false</c> otherwise.</returns>
    public bool IsActive()
    {
        return _isRunning;
    }




}