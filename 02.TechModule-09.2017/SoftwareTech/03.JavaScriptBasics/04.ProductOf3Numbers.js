function solution(arr){
    let n1 = Number(arr[0]);
    let n2 = Number(arr[1]);
    let n3 = Number(arr[2]);
    let result = true;
    if(n1 < 0){
        result = !result;
    }

    if(n2 < 0){
        result = !result;
    }

    if(n3 < 0){
        result = !result;
    }

    if(result){
        return "Positive";
    }
    else{
        return "Negative";
    }
}