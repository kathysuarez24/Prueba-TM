class RolService{
    axios
    baseUrl2

    constructor(axios,apiUrl){
        this.axios= axios
        this.baseUrl2= `${apiUrl}Rol`

    }

    getAllRol(){
        let self = this;
        return self.axios.get(`${self.baseUrl2}`);

    }

    add(model){
        let self = this;
        return self.axios.post(`${self.baseUrl2}`,model);
    }

    update(model){
        let self = this;
        return self.axios.put(`${self.baseUrl2}`,model);
    }

    get(id){
        let self = this;
        return self.axios.get(`${self.baseUrl2}/${id}`);
    }

    delete(id){
        let self = this;
        return self.axios.delete(`${self.baseUrl2}/${id}`);
    }
}

export default RolService