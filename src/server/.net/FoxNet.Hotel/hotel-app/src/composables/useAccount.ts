import { ref } from "vue"
import Consts from "../consts"
import axios from "axios";

const fetchDataURI = Consts.API.concat(`users/1`);
const sendDataURI = Consts.API.concat('users/edit');

const headers = {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Methods': 'GET',
    'Access-Control-Allow-Origin': `${fetchDataURI}`
};

export const useAccount = () => {
    const User = ref([]);
    
    const fetchUserData = () => {
        fetch(fetchDataURI, { headers })
        .then(response => response.json())
        .then(data => (User.value = data))
        .catch(error => console.error(error))
    };

    const sendUserData = () => {
        axios.post(sendDataURI, User.value)
        .then(response => console.log(response))
        .catch(error => console.log(error))
    };

    return  { 
        User,
        fetchUserData,
        sendUserData,
    }
}