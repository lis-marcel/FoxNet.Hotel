<template>
    <br>
    <section class="vh-100 bg-image">
        <div class="mask d-flex align-items-center h-100 gradient-custom-3">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-5">
                            <h2 class="text-uppercase text-center mb-5">Create an account</h2>
                                <form>
                                    <div class="form-outline mb-4">
                                        <input type="text" id="form3Example1cg" class="form-control form-control-lg" v-model="registerData.UserName"/>
                                        <label class="form-label" for="form3Example1cg">Name</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="text" id="form3Example1cg" class="form-control form-control-lg" v-model="registerData.UserSurname"/>
                                        <label class="form-label" for="form3Example1cg">Surname</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="date" id="form3Example1cg" class="form-control form-control-lg" v-model="registerData.Birth"/>
                                        <label class="form-label" for="form3Example1cg">Birthday</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="email" id="form3Example3cg" class="form-control form-control-lg" v-model="registerData.Email"/>
                                        <label class="form-label" for="form3Example3cg">Email</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="text" id="form3Example1cg" class="form-control form-control-lg" v-model="registerData.Phone"/>
                                        <label class="form-label" for="form3Example1cg">Phone</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="password" id="form3Example4cg" class="form-control form-control-lg" v-model="registerData.Password"/>
                                        <label class="form-label" for="form3Example4cg">Password</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="password" id="form3Example4cdg" class="form-control form-control-lg" />
                                        <label class="form-label" for="form3Example4cdg">Repeat password</label>
                                    </div>

                                    <!-- <div class="form-check d-flex justify-content-center mb-5">
                                        <input class="form-check-input me-2" type="checkbox" value="" id="form2Example3cg" />
                                        <label class="form-check-label" for="form2Example3g">
                                            I agree all statements in <a href="#!" class="text-body"><u>Terms of service</u></a>
                                        </label>
                                    </div> -->

                                    <div class="d-flex justify-content-center">
                                        <button type="button" @click="addUser()"
                                            class="btn btn-success btn-block btn-lg gradient-custom-4 text-body">
                                            Register
                                        </button>
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">Have already an account?
                                        <router-link to="/">Login here</router-link>
                                    </p>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script lang="ts">
import Consts from "../consts";

    export default {
        data() {
            return {
                registerData: {
                    UserName: null,
                    UserSurname: null,
                    Birth: null,
                    Email: null,
                    Password: null,
                    Phone: null
                }
            }
        },

        methods: {
            addUser() {
                console.log(this.registerData)

                const URI = Consts.API.concat('users/add')

                fetch(URI, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Access-Control-Allow-Methods': 'POST',
                        'Access-Control-Allow-Origin': `${URI}`
                    },
                    body: JSON.stringify(this.registerData)
                })
            }
        }
    }
</script>