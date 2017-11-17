function solution(arr){
    let N = Number(arr[0]);
    let X = Number(arr[1]);
    let result = 0;
    if(X >= N){
        result = N*X;
    }
    else{
        result = N/X;
    }

    return result;
}

console.log(solution(["9","7"]));