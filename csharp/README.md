# Codility Lessons - JavaScript

## Lesson 1 - Iterations

### BinaryGap
Find longest sequence of zeros in binary representation of an integer.

**Description**

A binary gap within a positive integer N is any maximal sequence of consecutive zeros
that is surrounded by ones at both ends in the binary representation of N.

For example, number 9 has binary representation 1001 and contains a binary gap of length 2.
The number 529 has binary representation 1000010001 and contains two binary gaps:
one of length 4 and one of length 3. 
The number 20 has binary representation 10100 and contains one binary gap of length 1. 
The number 15 has binary representation 1111 and has no binary gaps.
The number 32 has binary representation 100000 and has no binary gaps.

Write a function:

function solution(N);

that, given a positive integer N, returns the length of its longest binary gap.
The function should return 0 if N doesn't contain a binary gap.

For example, given N = 1041 the function should return 5,
because N has binary representation 10000010001 and so its longest binary gap is of length 5.
Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..2,147,483,647].


**Solution**

```javascript
function solution(N) {
    // convert integer to binary string
    let binary = N.toString(2);
    // convert string to an array of characters
    let bArray = [...binary];
    let gaps = [];
    let counter = 0;
    for(let i = 0; i < bArray.length; i++) {
        let isZero = parseInt(bArray[i]) === 0;
        let isOne = parseInt(bArray[i]) > 0;

        if(isZero) {
            counter++;
        }

        if(isOne) {
            if(counter > 0) {
                gaps.push(counter);
            }
            counter = 0;
        }
    }

    if(gaps.length > 0) {
        return Math.max(...gaps);
    } else {
        return 0;
    }
}
```

**Takeaways**

    Convert integer to binary string with N.toString(2);
    Using spread operator ... to pass an array as a list of arguments to a function, i.e.
    Math.min(...gaps), instead of Math.min.apply(null, gaps).
 


**Codility Score** 

https://app.codility.com/demo/results/trainingCC3X7Y-T37/


## Lesson 2 - Arrays

### CyclicRotation
Rotate an array to the right by a given number of steps

**Description**

An array A consisting of N integers is given. Rotation of the array means that each element 
is shifted right by one index, and the last element of the array is moved to the first place. 
For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] 
(elements are shifted right by one index and 6 is moved to the first place).

The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.

Write a function:

function solution(A, K);

that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.

For example, given

    A = [3, 8, 9, 7, 6]
    K = 3
the function should return [9, 7, 6, 3, 8]. Three rotations were made:

    [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
    [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
    [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]
For another example, given

    A = [0, 0, 0]
    K = 1
the function should return [0, 0, 0]

Given

    A = [1, 2, 3, 4]
    K = 4
the function should return [1, 2, 3, 4]

Assume that:

N and K are integers within the range [0..100];
// each element of array A is an integer within the range [−1,000..1,000].
In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.

**Solution**
```javascript
function solution(A, K) {
    if(A.length) {
        for(var i = 0; i < K; i++) {
            A.unshift(A.pop());
        }
    }
    return A;
}
```

**Takeaways**

    push/pop - add/remove elements from the end of an array
    shift/unshift - add/remove elements from the beginning of an array
 


**Codility Score**

https://app.codility.com/demo/results/trainingTSN8XH-JD8/


### OddOccurrencesInArray
Find value that occurs in odd number of elements.

**Description**

A non-empty array A consisting of N integers is given. 
The array contains an odd number of elements, and each element of the 
array can be paired with another element that has the same value, 
except for one element that is left unpaired.

For example, in array A such that:


    A[0] = 9  A[1] = 3  A[2] = 9
    A[3] = 3  A[4] = 9  A[5] = 7
    A[6] = 9

    the elements at indexes 0 and 2 have value 9,
    the elements at indexes 1 and 3 have value 3,
    the elements at indexes 4 and 6 have value 9,
    the element at index 5 has value 7 and is unpaired.

Write a function:

function solution(A);

that, given an array A consisting of N integers fulfilling the above conditions, 
returns the value of the unpaired element.

For example, given array A such that:


    A[0] = 9  A[1] = 3  A[2] = 9
    A[3] = 3  A[4] = 9  A[5] = 7
    A[6] = 9

    the function should return 7, as explained in the example above.

Write an efficient algorithm for the following assumptions:

N is an odd integer within the range [1..1,000,000];
each element of array A is an integer within the range [1..1,000,000,000];
all but one of the values in A occur an even number of times.

**Solution**
```javascript
function solution(A) {
    let occurrences = new Map();

    A.forEach((key) => {
        let val = 0;
        if(occurrences.has(key)) {
            val = occurrences.get(key) + 1;
        } else {
            val = 1;
        }
        occurrences.set(key, val);
    })

    let uniqueKey = 0;
    for(const [key, value] of occurrences) {
        if(value % 2 === 1) {
            uniqueKey = key;
            break;
        }
    }

    return uniqueKey;
}
```


**Takeaways**

    Using the Map object as a hashmap.
    Using for(const[key, value] of Map) to extract the key and value from the Map object as I iterate through it. Also, allows me to break out of it once a condition has been met.



**Codility Score**

https://app.codility.com/demo/results/trainingPF3WGM-DSJ/

## Lesson 3 - Time Complexity

### FrogImp
Count minimal number of jumps from position X to Y.

**Description**

A small frog wants to get to the other side of the road. 
The frog is currently located at position X and wants to get to a 
position greater than or equal to Y. The small frog always jumps a fixed distance, D.

Count the minimal number of jumps that the small frog must perform to reach its target.

Write a function:

function solution(X, Y, D);

that, given three integers X, Y and D, returns the minimal number 
of jumps from position X to a position equal to or greater than Y.

For example, given:


    X = 10
    Y = 85
    D = 30

the function should return 3, because the frog will be positioned as follows:

after the first jump, at position 10 + 30 = 40
after the second jump, at position 10 + 30 + 30 = 70
after the third jump, at position 10 + 30 + 30 + 30 = 100

Write an efficient algorithm for the following assumptions:

X, Y and D are integers within the range [1..1,000,000,000];
X ≤ Y.

**Solution**
```javascript
function solution(X, Y, D) {
    if(X < Y) {
        let counter = Math.floor((Y - X)/ D);
        let position = counter * D + X;
        while(position < Y) {
            position += D;
            counter++;
        }
        return counter;
    } else {
        return 0;
    }
}
```

**Takeaways**

    Not much takeaway from this lesson from a language perspective, 
    except maybe the use of Math.floor to remove 
    the remainder on the division.

**Codility Score**

https://app.codility.com/demo/results/trainingVPM633-TAX/


### PermMissingElem
Find the missing element in a given permutation.

**Description**

An array A consisting of N different integers is given. 
The array contains integers in the range [1..(N + 1)], 
which means that exactly one element is missing.

Your goal is to find that missing element.

Write a function:

function solution(A);

that, given an array A, returns the value of the missing element.

For example, given array A such that:

    A[0] = 2
    A[1] = 3
    A[2] = 1
    A[3] = 5

the function should return 4, as it is the missing element.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [0..100,000];
the elements of A are all distinct;
each element of array A is an integer within the range [1..(N + 1)].

**Solution**
```javascript
function solution(A) {
    let map = [];
    let index = 1;
    for(let i = 0; i < A.length + 1; i++) {
        map[A[i]] = true;
    }

    while( index < A.length + 1) {
        if(!map[index]) break;
        index++;
    }

    return index;
}
```

**Takeaways**
    The use of 2 loops instead of searching the array
    for each element. Also the use of a temporary map array to restructure the original array into a new datastructure and leverage the key/value
    strenghts of arrays.


**Codility Score**

https://app.codility.com/demo/results/trainingGESCWG-TJD/




### TapeEquilibrium
Mini the value |(A[0]...+A[P-1]) - (A[P]+...+A[N-1])|
.

**Description**

**Solution**
```javascript
    let lower = [A.length];
    let upper = [A.length];

    lower.push(0);

    for(let i = 0; i < A.length; i++) {
        let iRev = A.length - i - 1;

        if(i === 0) {
            lower[i] = 0;
        } else {
            lower[i] = lower[i-1] + A[i-1];
        }

        if(iRev === A.length - 1) {
            upper[iRev] = A[iRev];
        } else {
            upper[iRev] = upper[iRev + 1] + A[iRev];
        }
    }

    let result = Math.abs(lower[1] - upper[1]);

    for(let i = 2; i < lower.length; i++) {
        let diff = Math.abs(lower[i] - upper[i]);
        if(diff < result) {
            result = diff;
        }
    }

    return result;
```

**Takeaways**

    My original solution was using reduce for
    summation, which was ~600ms too slow. 
    The key to solving this performance-wise
    was adding in both directions during the 
    first loop.

**Codility Score**
https://app.codility.com/demo/results/training49CTXJ-WZX/


## Lesson 4 - Counting Elements

### FrogRiverOne
Find the earliest time when a frog can jump to the other side of a river.

**Description**

A small frog wants to get to the other side of a river. The frog is initially located on one bank of the river (position 0) and wants to get to the opposite bank (position X+1). Leaves fall from a tree onto the surface of the river.

You are given an array A consisting of N integers representing the falling leaves. A[K] represents the position where one leaf falls at time K, measured in seconds.

The goal is to find the earliest time when the frog can jump to the other side of the river. The frog can cross only when leaves appear at every position across the river from 1 to X (that is, we want to find the earliest moment when all the positions from 1 to X are covered by leaves). You may assume that the speed of the current in the river is negligibly small, i.e. the leaves do not change their positions once they fall in the river.

For example, you are given integer X = 5 and array A such that:


    A[0] = 1
    A[1] = 3
    A[2] = 1
    A[3] = 4
    A[4] = 2
    A[5] = 3
    A[6] = 5
    A[7] = 4

In second 6, a leaf falls into position 5. This is the earliest time when leaves appear in every position across the river.

Write a function:

function solution(X, A);

that, given a non-empty array A consisting of N integers and integer X, returns the earliest time when the frog can jump to the other side of the river.

If the frog is never able to jump to the other side of the river, the function should return −1.

For example, given X = 5 and array A such that:

    A[0] = 1
    A[1] = 3
    A[2] = 1
    A[3] = 4
    A[4] = 2
    A[5] = 3
    A[6] = 5
    A[7] = 4

the function should return 6, as explained above.

Write an efficient algorithm for the following assumptions:

N and X are integers within the range [1..100,000];
each element of array A is an integer within the range [1..X].

**Solution**
```javascript

```

**Takeaways**

**Codility Score**

