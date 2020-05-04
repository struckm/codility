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

**Takeaways**

    push/pop - add/remove elements from the end of an array
    shift/unshift - add/remove elements from the beginning of an array
 


**Codility Score** 
https://app.codility.com/demo/results/trainingTSN8XH-JD8/
