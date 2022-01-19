import axios from 'axios'
import React, {Fragment,useEffect,useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import LibrosporautoresI from './LibrosporautoresI';


const Librosporautores = () => {
    const [data,setData]=useState([]);
    useEffect(()=>{
        axios.get('https://localhost:44322/api/ServicioWebAPICore/ListarAutores')
        .then(resp=>{
            setData(resp.data);
        })
        .catch(error=>{
            console.log(error);
        })
    },[]);
     var num_resgistros=data.length;

     const [id_autor,setIdAutor]=useState("");
     function GetIdAutor(e){
         
         setIdAutor(e.target.value);
     };


  return(
    <div>
        <center>
        <h1>
        Libros Vendidos por Autor
        </h1>
        <br/>
        <h3>Libros Escritos por Autor seleccionado  {id_autor} </h3>
        <br/>
        <select name='cboautor' className='form-control' 
            value={id_autor} onChange={(e)=>GetIdAutor(e)}>
                {
                    data.map(item=>(
                        <option key={item.codAutor} value={item.codAutor}>
                            {item.nomAutor}
                        </option>
                    ))
                }
            </select>

            <br/>
            </center>
            <Fragment>
                <LibrosporautoresI ParamIdAutor={id_autor}/>
            </Fragment>
    </div>
  )
  
};

export default Librosporautores;
