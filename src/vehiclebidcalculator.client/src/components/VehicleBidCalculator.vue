<template>
    <div class="jumbotron vertical-center">
        <div class="container">
            <div class="row">
                <div class="col calculation-pane">
                    <form @submit.prevent="submitCalculationFormAsync">
                        <br />
                        <div class="form-group">
                            <label for="formVehiclePrice">Vehicle Price</label>
                            <input type="number" 
                                   step=".01" 
                                   placeholder='0.00'
                                   class="form-control" 
                                   id="formVehiclePrice" 
                                   v-model="calculationForm.vehiclePrice" />
                        </div>

                        <div class="form-group">
                            <label for="formVehicleType">Vehicle Type</label>
                            <select class="form-select" 
                                    id="formVehicleType" 
                                    v-model="calculationForm.vehicleType">
                                <option value="Common">Common</option>
                                <option value="Luxury">Luxury</option>
                            </select>
                        </div>

                        <br />
                        <button type="submit" class="btn btn-secondary">Calculate</button>
                    </form>
                </div>
                <div class="col result-pane">
                    <br />
                    <div class="form-group">
                        <label for="resultVehiclePrice">Vehicle Price</label>
                        <input type="number" 
                               step=".01" 
                               class="form-control" 
                               id="resultVehiclePrice" 
                               v-model="calculationResult.vehiclePrice"
                               readonly />
                    </div>

                    <div class="form-group">
                        <label for="resultVehicleType">Vehicle Type</label>
                        <input type="text" 
                               class="form-control" 
                               id="resultVehicleType"
                               v-model="calculationResult.vehicleType"
                               readonly />
                    </div>

                    <div class="form-group">
                        <label for="resultBasicFee">Basic Fee</label>
                        <input type="number" step=".01" 
                               class="form-control" 
                               id="resultBasicFee" 
                               v-model="calculationResult.basicFee"
                               readonly />
                    </div>

                    <div class="form-group">
                        <label for="resultSpecialFee">Special Fee</label>
                        <input type="number" 
                               step=".01"
                               class="form-control"
                               id="resultSpecialFee" 
                               v-model="calculationResult.specialFee"
                               readonly />
                    </div>

                    <div class="form-group">
                        <label for="resultAssociationFee">Association Fee</label>
                        <input type="number"
                               step=".01" 
                               class="form-control" 
                               id="resultAssociationFee" 
                               v-model="calculationResult.associationFee"
                               readonly />
                    </div>

                    <div class="form-group">
                        <label for="resultStorageFee">Storage Fee</label>
                        <input type="number"
                               step=".01" 
                               class="form-control" 
                               id="resultStorageFee" 
                               v-model="calculationResult.storageFee" 
                               readonly />
                    </div>

                    <br />
                    <br />
                    <div class="form-group">
                        <label for="resultTotal"><b>Total</b></label>
                        <input type="number" 
                               step=".01" 
                               class="form-control" 
                               id="resultTotal"
                               v-model="calculationResult.total"
                               readonly />
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    const vehicleCommonType: string = "Common";
    const vehicleLuxuryType: string = "Luxury";

    const vehicleBidCalculationEndpoint: string = "api/vehicle-bids/calculation";

    type VehicleBidCalculationForm = {
        vehiclePrice: number,
        vehicleType: string,
    };

    type VehicleBidCalculationResult = VehicleBidCalculationForm & {
        basicFee: number,
        specialFee: number,
        associationFee: number,
        storageFee: number,
        total: number,
    };

    type Data = {
        loading: boolean,
        calculationForm: VehicleBidCalculationForm,
        calculationResult: VehicleBidCalculationResult,
    };

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                calculationForm: null,
                calculationResult: null,
            };
        },
        created() {
            this.fetchDataAsync();
        },
        watch: {
            '$route': 'fetchDataAsync'
        },
        methods: {
            async fetchDataAsync(): void {
                this.loading = true;

                this.calculationForm = {
                    vehiclePrice: 0,
                    vehicleType: vehicleCommonType,
                } as VehicleBidCalculationForm;

                this.calculationResult = {
                    vehiclePrice: 0,
                    vehicleType: vehicleCommonType,
                    basicFee: 0,
                    specialFee: 0,
                    associationFee: 0,
                    storageFee: 0,
                    total: 0,
                } as VehicleBidCalculationResult;
            },
            async submitCalculationFormAsync() {
                const calculationForm = {
                    vehiclePrice: this.calculationForm.vehiclePrice,
                    vehicleType: this.calculationForm.vehicleType,
                };

                const request = new Request(vehicleBidCalculationEndpoint, {
                    headers: {
                        "Content-Type": "application/json"
                    },
                    method: "POST",
                    body: JSON.stringify(calculationForm),
                });

                const response = await fetch(request);
                const data = await response.json();
                this.calculationResult = data as VehicleBidCalculationResult;
            },
        },
    });
</script>

<style scoped>
    .vertical-center {
        min-height: 75vh;
        display: flex;
        align-items: center;
    }

    .calculation-pane {
        background: #f0f1d7;
    }

    .result-pane {
        background: #f0f0fa;
    }
</style>