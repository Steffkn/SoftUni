function solution(arr){
    let N = Number(arr[0]);
    let numArray = {};

    for(let i = 0; i < N; i++){
        numArray[i] = 0;
    }

    for(let i = 1; i < arr.length; i++){
        let index = arr[i].split(" - ")[0];
        let number = arr[i].split(" - ")[1];
        numArray[index] = number;
    }

    for(const aa in numArray){
        console.log(numArray[aa]);
    }
}

solution([
    "3",
    "0 - 5",
    "1 - 6",
    "2 - 7",
])

solution([
    "2",
    "0 - 5",
    "0 - 6",
    "0 - 7",
])