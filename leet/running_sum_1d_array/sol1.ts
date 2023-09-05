function runningSum(nums: number[]): number[] {
  return nums.map((num, index) => {
    let sum = 0;
    for (let i = 0; i <= index; i++) {
      sum += nums[i];
    }
    return sum;
  });
}
