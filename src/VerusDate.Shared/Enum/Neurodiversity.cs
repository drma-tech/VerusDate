using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.verywellmind.com/what-is-neurodivergence-and-what-does-it-mean-to-be-neurodivergent-5196627
    /// </summary>
    public enum Neurodiversity
    {
        [Custom(Name = "Neurotypical", Description = "Neurotypical is a descriptor that refers to someone who has the brain functions, behaviors, and processing considered standard or typical.")]
        Neurotypical,

        [Custom(Name = "Neurodivergent", Description = "Neurodivergence is the term for people whose brains function differently in one or more ways than is considered standard or typical. There are many different ways that neurodivergence manifests, ranging from very mild ways that most people would never notice to more obvious ways that lead to a person behaving differently than is standard in our society. Several \"recognized\" types of Neurodivergence, include autism, Asperger's syndrome, dyslexia, dyscalculia, epilepsy, hyperlexia, Dyspraxia, ADHD, obsessive-compulsive disorder (OCD), and Tourette syndrome (TS).")]
        Neurodivergent
    }
}