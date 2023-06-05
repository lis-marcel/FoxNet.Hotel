<template>
    <div class="container rounded bg-white mt-5 mb-5">
        <div class="row">
            <div class="col-md-3 border-right">
                <!-- <div class="d-flex flex-column align-items-center text-center p-3 py-5"><img class="rounded-circle mt-5" width="150px" src="https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg">
                    <span class="font-weight-bold"> {{ User.name }} {{ User.surname }}</span>
                    <span class="text-black-50"> {{ User.email }} </span>
                    <span> </span>
                </div> -->
            </div>
            <div class="col-md-5 border-right">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h4 class="text-right">Profile Settings</h4>
                    </div>
                    <div class="row mt-2">
                        <div class="col-md-6"><label class="labels">Name</label><input type="text" class="form-control" placeholder="first name" v-model="User.userName" /></div>
                        <div class="col-md-6"><label class="labels">Surname</label><input type="text" class="form-control" placeholder="surname" v-model="User.userSurname" /></div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-12"><label class="labels">Password</label><input type="text" class="form-control" placeholder="password" v-model="User.password" /></div>
                        <div class="col-md-12"><label class="labels">Phone Number</label><input type="text" class="form-control" placeholder="phone number" v-model="User.phone" /></div>
                        <div class="col-md-12"><label class="labels">Email</label><input type="text" class="form-control" placeholder="email" v-model="User.email" /></div>
                        <div class="col-md-12"><label class="labels">Birthday</label><input type="date" class="form-control" placeholder="birth" v-model="User.birth" :format="'DD.MM.YYYY'" /></div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6"><label class="labels">Account Type:</label><p>User</p></div>
                    </div>
                    <div class="mt-5 text-center">
                        <button class="btn btn-danger profile-button" type="button">Log Out</button>
                        <button class="btn btn-primary profile-button m-3" type="button" @click="sendUserData()">Save Profile</button>
                    </div>
                </div>
            </div>
            <!-- <div class="col-md-4">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center experience"><span class="border px-3 p-1 add-experience"><i class="fa fa-plus"></i>   Wallet</span></div><br>
                    <div class="col-md-12"><label class="labels">Value</label><input type="text" class="form-control" placeholder="value" v-model="User.money" /></div> <br>
                    <div class="col-md-12"><label class="labels">Add Funds</label><input type="number" class="form-control" placeholder="value" /></div>
                </div>
            </div> -->
        </div>
    </div>
</template>

<script lang="ts">
import { useAccount } from '@/composables/useAccount';

    export default {
        setup(props: any, context: any) {
            const { User, fetchUserData, sendUserData } = useAccount();

            fetchUserData();

            return {
                User,
                sendUserData,
            }
        },
    }
</script>