import React from 'react'

const Inicio = () => {
    var fecha=new Date();
    var mes= fecha.getMonth()+1;
    var dia=fecha.getDate();
    var anio=fecha.getFullYear();
    if(dia<10)
        dia='0'+dia; //agrega cero si es menor de 10
    if(mes<10)
        mes='0'+mes; //agrega cero si es menor de 10
    var fechafinal= dia+'/'+mes+'/'+anio;
    return (
        <div>
            <h1>Bienvenido a la Pagina de Consultas <br/>
                con la Base de Datos BDVENTALIBROS<br/>
                Fecha del Sistema : {fechafinal}
            </h1>
        </div>
    )
}

export default Inicio
