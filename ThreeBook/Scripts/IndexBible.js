
function GetFirstBook() {
    let result;
    const kol = async () => {
       
        const response = await fetch("./FirstBook").then((response) => {
            return response.json();
        }).then((data) => {
            console.log("book = ", data);
            result = data;
         });;
        return response;
    }
    kol();

}