<template>
    <section class="vh-100 bg-image">
        <div class="mask d-flex align-items-center h-100 gradient-custom-3">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-5">
                            <h2 class="text-uppercase text-center mb-5">Log in</h2>
                                <form>
                                    <div class="form-outline mb-4">
                                        <input type="email" id="form3Example3cg" class="form-control form-control-lg" v-model="loginData.email"/>
                                        <label class="form-label" for="form3Example3cg">Email</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="password" id="form3Example4cg" class="form-control form-control-lg" v-model="loginData.password"/>
                                        <label class="form-label" for="form3Example4cg">Password</label>
                                    </div>

                                    <div class="d-flex justify-content-center">
                                        <button type="button" class="btn btn-success btn-block btn-lg gradient-custom-4 text-body" @click="loginUser()">
                                            Log in
                                        </button>
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">Don't have account? 
                                        <router-link to="/register">Sign up here</router-link>
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
                loginData: {
                    email: null,
                    password: null,
                }
            }
        },

        methods: {
            async loginUser() {
                const URI = Consts.API.concat('users/login')

                const response = await fetch(URI, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Access-Control-Allow-Methods': 'POST',
                        'Access-Control-Allow-Origin': `${URI}`
                    },
                    body: JSON.stringify(this.loginData)
                })

                console.log(response)
            }
        }
    }
</script>