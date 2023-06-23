
function GetFirstBook() {
    let result;
    let getKol = async () => {
       
        const response = await fetch("/Home/FirstBook")
            .then((response) => {
                return response.json();
            }).then((data) => {
                console.log("book = ", data);
                result = data;
                return result;
            }).catch(err => console.log("ERROR = ", err));
        
    }
    getKol();
   
    var kol = [3, 5, 7, 9];
    var t = kol.find(a => a == 7);
    var tt = [...kol, 999];
    var ttt = kol.push(666);
    console.log("00000 = ", t);
    console.log("00001 = ", tt);
    console.log("00002 = ", ttt);
    
    
}
console.log("00003   " );
document.cookie = "deletename=kol_; expires=Thu, 18 Dec 2024 12:00:00 UTC; path=/";