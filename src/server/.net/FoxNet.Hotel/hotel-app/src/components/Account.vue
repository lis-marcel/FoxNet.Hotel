<template>
    <div class="container rounded bg-white mt-5 mb-5">
        <div class="row">
            <div class="col-md-3 border-right">
                <div class="d-flex flex-column align-items-center text-center p-3 py-5"><img class="rounded-circle mt-5" width="150px" src="https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg">
                    <span class="font-weight-bold">Name</span>
                    <span class="text-black-50">your.email@example.com</span>
                    <span> </span>
                </div>
            </div>
            <div class="col-md-5 border-right">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h4 class="text-right">Profile Settings</h4>
                    </div>
                    <div class="row mt-2">
                        <div class="col-md-6"><label class="labels">Name</label><input type="text" class="form-control" placeholder="first name" v-model="userData.name" /></div>
                        <div class="col-md-6"><label class="labels">Surname</label><input type="text" class="form-control" placeholder="surname" v-model="userData.surname" /></div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-12"><label class="labels">Password</label><input type="text" class="form-control" placeholder="password" v-model="userData.password" /></div>
                        <div class="col-md-12"><label class="labels">Phone Number</label><input type="text" class="form-control" placeholder="phone number" v-model="userData.phone" /></div>
                        <!-- <div class="col-md-12"><label class="labels">Email</label><input type="text" class="form-control" placeholder="email" v-model="userData.email" /></div> -->
                        <div class="col-md-12"><label class="labels">Birthday</label><input type="date" class="form-control" placeholder="birth" v-model="userData.birth" /></div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6"><label class="labels">Account Type</label><p>User</p></div>
                    </div>
                    <div class="mt-5 text-center">
                        <button class="btn btn-danger profile-button" type="button">Log Out</button>
                        <button class="btn btn-primary profile-button" type="button" @click="SendData()">Save Profile</button>
                        <button class="btn btn-primary profile-button" type="button" @click="TransferMoney()">Transfer Money</button>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center experience"><span class="border px-3 p-1 add-experience"><i class="fa fa-plus"></i>   Wallet</span></div><br>
                    <div class="col-md-12"><label class="labels">Value</label><input type="text" class="form-control" placeholder="value" v-model="userData.money" /></div> <br>
                    <div class="col-md-12"><label class="labels">Add Funds</label><input type="number" class="form-control" placeholder="value" v-model="additionalMoney" /></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import axios from   "axios";
import { onMounted } from 'vue';
import Consts from '../consts';

    export default {
        data() {
            return {
                additonalMoney: null,

                userData: {
                    id: null,
                    name: null,
                    surname: null,
                    passsword: null,
                    phone: null,
                    birth: null,
                    money: null,
                }
            }
        },

        methods: {
            FetchData() {
                const URI = Consts.API.concat(`users/7`)
                const headers = {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Methods': 'GET',
                    'Access-Control-Allow-Origin': `${URI}`
                }

                fetch(URI, { headers })
                .then(response => response.json())
                .then(data => (this.userData = data))
                .catch(error => console.error(error))
            },

            SendData() {
                const URI = Consts.API.concat('users/edit')

                axios.post(URI, this.userData)
                .then(response => console.log(response))
                .catch(error => console.log(error))
            },

            TransferMoney() {
                const URI = Consts.API.concat('users/money')

                this.userData.money += this.additionalMoney;

                console.log(this.userData.money)

                axios.post(URI, this.additionalMoney)
                .then(response => console.log(response))
                .catch(error => console.log(error))
            }
        },

        mounted() {
            this.FetchData();
        }
    }
</script>