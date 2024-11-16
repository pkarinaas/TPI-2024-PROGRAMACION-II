var attempt=3
function validate(){
    var user=document.getElementById("user").value;
    var pass=document.getElementById("pass").value;
    if(user=="admin" && pass=="Admin123__"){
        alert("ingreso exitoso")
        window.location="inicio.html";
        return false;
    }
    else{
        attempt--;
    }
    alert("te quedan " +attempt+ " intentos mas")
    if(attempt==0){
        document.getElementById("user").disabled=true;
        document.getElementById("pass").disabled=true;
        document.getElementById("submit").disabled=true;
    }
}